CREATE DATABASE FamaFeiradb;
    
-- -----------------------------------------------------
-- Schema FamaFeiradb
-- -----------------------------------------------------

USE FamaFeiradb;

-- DROP TABLE [FamaFeiradb].[dbo].[Administrador] 
CREATE TABLE [FamaFeiradb].[dbo].[Administrador](
    idAdmin INT IDENTITY(1,1) PRIMARY KEY ,
	username VARCHAR(50) NOT NULL,
	password VARCHAR(100) NOT NULL
);

-- DROP TABLE [FamaFeiradb].[dbo].[Cliente] 
CREATE TABLE [FamaFeiradb].[dbo].[Cliente](
    idCliente INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(50) NOT NULL,
    username VARCHAR(50) NOT NULL,
    telemovel VARCHAR(50) NOT NULL,
    password VARCHAR(100) NOT NULL,
	email VARCHAR(50) NOT NULL,
    morada VARCHAR(50) NOT NULL,
);

CREATE TABLE [FamaFeiradb].[dbo].[Expositor] (
  idExpositor INT IDENTITY(1,1) PRIMARY KEY ,
  nome VARCHAR(45) NOT NULL,
  username VARCHAR(45) NOT NULL,
  password VARCHAR(45) NOT NULL,
);
-- DROP TABLE [FamaFeiradb].[dbo].[Compra]
CREATE TABLE [FamaFeiradb].[dbo].[Compra] (
  idCompra INT IDENTITY(1,1) PRIMARY KEY ,
  data_compra VARCHAR(50) NOT NULL,
  quantidade INT NOT NULL,
  fk_idCliente INT NOT NULL,
  fk_idExpositor INT NOT NULL,
  CONSTRAINT fk_Cliente FOREIGN KEY(fk_idCliente) REFERENCES [FamaFeiradb].[dbo].[Cliente](idCliente),
  CONSTRAINT fk_Expositor3 FOREIGN KEY(fk_idExpositor) REFERENCES [FamaFeiradb].[dbo].[Expositor](idExpositor)
);

-- DROP TABLE [FamaFeiradb].[dbo].[Feira] 
CREATE TABLE [FamaFeiradb].[dbo].[Feira](
    idFeira INT IDENTITY(1,1) PRIMARY KEY ,
    tipo VARCHAR(50) NOT NULL,
	designacao VARCHAR(50) NOT NULL,
    localizacao VARCHAR(50) NOT NULL,
	imagem VARCHAR(150) NULL,
	dataFeira VARCHAR(50) NOT NULL,
	fk_idAdmin INT NULL,
    CONSTRAINT fk_Administrador FOREIGN KEY(fk_idAdmin) REFERENCES [FamaFeiradb].[dbo].[Administrador](idAdmin)
);
-- DROP TABLE [FamaFeiradb].[dbo].[Produto]
CREATE TABLE [FamaFeiradb].[dbo].[Produto] (
  idProduto INT IDENTITY(1,1) PRIMARY KEY,
  preco FLOAT NOT NULL,
  nome VARCHAR(45) NOT NULL,
  imagem VARCHAR(200) NOT NULL,
  codigo VARCHAR(45) NOT NULL,
  fk_idExpositor INT NOT NULL,
  CONSTRAINT fk_Expositor2 FOREIGN KEY(fk_idExpositor) REFERENCES [FamaFeiradb].[dbo].[Expositor](idExpositor)
);

CREATE TABLE [FamaFeiradb].[dbo].[CompraProduto] (
   valor FLOAT NOT NULL,
   produto_idProduto INT NOT NULL,
   compra_idCompra INT NOT NULL,
   PRIMARY KEY (Produto_idProduto, Compra_idCompra),
   CONSTRAINT fk_Produto FOREIGN KEY(produto_idProduto) REFERENCES [FamaFeiradb].[dbo].[Produto](idProduto),
   CONSTRAINT fk_Compra FOREIGN KEY(compra_idCompra) REFERENCES [FamaFeiradb].[dbo].[Compra](idCompra)
);

-- DROP TABLE [FamaFeiradb].[dbo].[Stand] 
CREATE TABLE [FamaFeiradb].[dbo].[Stand](
    idStand INT IDENTITY(1,1) PRIMARY KEY ,
    designacao VARCHAR(50) NOT NULL,
	descricao VARCHAR(150) NOT NULL,
	imagem VARCHAR(150) NOT NULL,
	recomendacao VARCHAR(50) NULL,
	empresa VARCHAR(50) NOT NULL,
	fk_idExpositor INT NOT NULL,
    fk_idAdmin INT NOT NULL,
    fk_idFeira INT NULL,
    CONSTRAINT fk_Expositor FOREIGN KEY(fk_idExpositor) REFERENCES [FamaFeiradb].[dbo].[Expositor](idExpositor),
	CONSTRAINT fk_Administrador2 FOREIGN KEY(fk_idAdmin) REFERENCES [FamaFeiradb].[dbo].[Administrador](idAdmin),
    CONSTRAINT fk_feira FOREIGN KEY(fk_idFeira) REFERENCES [FamaFeiradb].[dbo].[Feira](idFeira)
);
