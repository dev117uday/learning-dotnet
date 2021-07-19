


```sql
CREATE TABLE IF NOT EXISTS users (
    user_id SERIAL PRIMARY KEY ,
    user_name VARCHAR(50),
    user_email VARCHAR(50)
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
            CHECK (user_email ~* '^[A-Za-z]+[A-Za-z0-9.]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$');
    END IF;
END$$;

INSERT INTO users (user_name, user_email)
    values ('uday yadav','yadav117uday@gmail.com') returning user_id;
SELECT * FROM users WHERE user_id = 1;
UPDATE users
        SET user_name = 'uday yadav x', user_email = 'yadav@gmail.com'
        WHERE user_id = 1;

select * from users;

DELETE FROM users WHERE user_id = 1;

drop table users;
```