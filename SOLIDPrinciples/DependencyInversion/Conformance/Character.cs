using System;
using System.Data;
using System.Data.SqlClient;

namespace SOLIDPrinciples.DependencyInversion.Conformance
{
    class Character
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Behavior { get; set; }
    }

    class CharacterRepository
    {
        private readonly ICharacterMapper _characterMapper;

        public CharacterRepository(ICharacterMapper characterMapper)
        {
            _characterMapper = characterMapper;
        }
        public Character Load(int id)
        {
            var sp_name = "getCharacter";
            using (var conn = new SqlConnection("connection.string"))
            using (var cmd = new SqlCommand(sp_name, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int);
                var reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    throw new NotFoundException(id);
                }

                return _characterMapper.Load(reader);
            }
        }
    }

    class CharacterMapper : ICharacterMapper
    {
        public Character Load(SqlDataReader reader)
        {
            return new Character()
            {
                Id = (int) reader["Character_Id"],
                Name = (string) reader["Name_tx"],
                Behavior = (string) reader["Behavior_tx"]
            };
        }
    }
    interface ICharacterMapper
    {
        Character Load(SqlDataReader reader);
    }

    class NotFoundException : Exception
    {
        public NotFoundException(int id)
        {
            Message = $"object with id '{id}' not found.";
        }

        public override string Message { get; }
    }
}
