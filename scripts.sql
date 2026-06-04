CREATE DATABASE IF NOT EXISTS projetogsdb;
USE projetogsdb;

CREATE TABLE categoriasimpacto (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL
);

CREATE TABLE usuarios (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    SenhaHash VARCHAR(255) NOT NULL,
    Perfil INT NOT NULL
);

CREATE TABLE tecnologias (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL,
    Descricao LONGTEXT NOT NULL,
    MissaoOrigem VARCHAR(255) NOT NULL,
    DataCadastro DATETIME NOT NULL,
    CategoriaImpactoId INT NOT NULL,
    CONSTRAINT FK_Tecnologias_CategoriasImpacto
        FOREIGN KEY (CategoriaImpactoId)
        REFERENCES categoriasimpacto(Id)
);

INSERT INTO categoriasimpacto (Nome) VALUES
('Saúde'),
('Educação'),
('Agricultura');

-- Usuário Administrador
-- Login: admin@fiap.com
-- Senha: admin123

-- Usuário Pesquisador
-- Login: pesquisador@fiap.com
-- Senha: pesquisa123

INSERT INTO usuarios (Nome, Email, SenhaHash, Perfil)
VALUES
(
    'Administrador',
    'admin@fiap.com',
    '$2a$11$5yETIPn1v3YQyYjgzvgN/.fETtzL.z0lnCf1MIJJrqAx3Mfb6mjqG',
    2
),
(
    'Pesquisador',
    'pesquisador@fiap.com',
    '$2a$11$hXwP86DL33O95Hkd5.EuPu0fbOdheIvuR0hw0Hr/UMASItmTK5J/S',
    1
);

select * from usuarios