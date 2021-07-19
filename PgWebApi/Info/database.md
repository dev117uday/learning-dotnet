
```sql

CREATE TABLE IF NOT EXISTS users (
    id SERIAL PRIMARY KEY ,
    name VARCHAR(50),
    email VARCHAR(50)
);

select * from users;

DO $$
BEGIN
    IF NOT EXISTS ( SELECT  constraint_schema, constraint_name
                FROM information_schema.check_constraints
                WHERE constraint_schema = 'public'
                AND constraint_name = 'email_check'
              )
    THEN
        ALTER TABLE public.users
            ADD CONSTRAINT email_check
            CHECK (email ~* '^[A-Za-z]+[A-Za-z0-9.]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$');
    END IF;
END$$;

INSERT INTO users (name, email)
    values ('uday yadav','yadav117uday@gmail.com') returning id;
SELECT * FROM users WHERE user_id = 1;
UPDATE users
        SET name = 'uday yadav x', email = 'yadav@gmail.com'
        WHERE id = 1;

select * from users;

DELETE FROM users WHERE id = 1;

drop table users;
```