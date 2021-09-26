            var cs = "User ID=pgsqluser;Password=Password02@117;Host=localhost;Port=5432;Database=AspNet;Pooling=true;";
            var db = new NpgsqlConnection(cs);
            db.Open();
            var user = new User {Sub = "1234567890", Email = "dev117uday@gmail.com", Name = "uday yadav"};
            string sql = "INSERT INTO users (sub,name,email) values (@Sub,@Name,@Email) ON CONFLICT DO NOTHING;";
            var data = await db.ExecuteAsync(sql, new {Sub = user.Sub, Name = user.Name, Email = user.Email});
            Console.WriteLine(data);