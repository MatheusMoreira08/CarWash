-- Init script do PostgreSQL — executado APENAS na primeira criação do volume
-- Cria role de aplicação separada do superuser (RT3, RNF003)

DO
$$
BEGIN
    IF NOT EXISTS (SELECT 1 FROM pg_roles WHERE rolname = 'carwash_app') THEN
        CREATE ROLE carwash_app WITH LOGIN PASSWORD 'CHANGE_ME_VIA_ENV';
    END IF;
END
$$;

-- Permissões básicas: usuário da aplicação só fala com o schema carwash
GRANT CONNECT ON DATABASE carwash TO carwash_app;
GRANT USAGE, CREATE ON SCHEMA public TO carwash_app;

-- Extensões úteis
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";
CREATE EXTENSION IF NOT EXISTS "citext";
