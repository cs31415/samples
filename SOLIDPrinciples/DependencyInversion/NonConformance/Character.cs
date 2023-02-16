using System;
using System.Data;
using System.Data.SqlClient;

namespace SOLIDPrinciples.DependencyInversion.NonConformance
{
    class Character
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public byte[] Icon { get; set; }
    }

    class CharacterRepository
    {
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

                return new Character()
                {
                    Id = (int)reader["Character_Id"],
                    Name = (string)reader["Name_tx"],
                    Icon = (byte[])reader["Icon_blob"]
                };
            }
        }
    }

    enum Characters
    {
        MickeyMouse = 1,
        DonaldDuck = 2,
        Goofy = 3
    };
    class Game
    {
        public void Main()
        {
            var repository = new CharacterRepository();

            var character = repository.Load((int) Characters.MickeyMouse);
        }
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
