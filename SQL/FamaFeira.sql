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
    CONSTRAINT fk_feira FOREIGN KEY(fk_idFeira) REFERENCES [FamaFeiradb].[dbo].[Feira](idFeira),
	CONSTRAINT fk_Administrador2 FOREIGN KEY(fk_idAdmin) REFERENCES [FamaFeiradb].[dbo].[Administrador](idAdmin),
    CONSTRAINT fk_Expositor FOREIGN KEY(fk_idExpositor) REFERENCES [FamaFeiradb].[dbo].[Expositor](idExpositor)
);

SELECT * FROM [FamaFeiradb].[dbo].[Cliente];
SELECT * FROM [FamaFeiradb].[dbo].[Compra];
SELECT * FROM [FamaFeiradb].[dbo].[CompraProduto];
SELECT * FROM [FamaFeiradb].[dbo].[Produto];
SELECT * FROM [FamaFeiradb].[dbo].[Expositor];
SELECT * FROM [FamaFeiradb].[dbo].[Administrador];
SELECT * FROM [FamaFeiradb].[dbo].[Feira];
SELECT * FROM [FamaFeiradb].[dbo].[Stand];
SELECT tipo,localizacao FROM [dbo].[Feira];

SELECT TOP 1 idCompra FROM [FamaFeiradb].[dbo].[Compra] ORDER BY idCompra DESC;

DELETE FROM [FamaFeiradb].[dbo].[Compra];
DELETE FROM [FamaFeiradb].[dbo].[Produto] WHERE idProduto=1;
SELECT COUNT(username) as total FROM [FamaFeiradb].[dbo].[Cliente]
		WHERE username='joao';

DELETE FROM [FamaFeiradb].[dbo].[Feira] WHERE idFeira = 4;
SELECT S.designacao FROM [FamaFeiradb].[dbo].[Feira] AS F
	INNER JOIN [FamaFeiradb].[dbo].[Stand] AS S ON F.idFeira=S.fk_idFeira WHERE F.tipo='Feira de Cultura';

-- DELETE FROM [FamaFeiradb].[dbo].[Cliente]; 
-- DELETE FROM [FamaFeiradb].[dbo].[Feira]; 

INSERT INTO [FamaFeiradb].[dbo].[Administrador] VALUES('admin','admin123');

UPDATE [FamaFeiradb].[dbo].[Produto] SET preco=150 WHERE codigo='C03X';
---apenas povoei a feira empresarial com 2 stands
INSERT INTO [FamaFeiradb].[dbo].[Feira] VALUES('Feira da Cultura','Feira A','Av. de França 1361,4760-282','https://portalantigo.marica.rj.gov.br/wp-content/uploads/2017/01/DSC0091-FOTO-FERNANDO-SILVA.jpg','13/10/2022',1);
INSERT INTO [FamaFeiradb].[dbo].[Feira] VALUES('Feira de Artesanato','Feira B','Rua de São Bento 217,4770-222 Joane','https://media-cdn.tripadvisor.com/media/photo-s/06/e5/27/8c/feira-de-arte-e-artesanato.jpg','16/10/2022',1);
INSERT INTO [FamaFeiradb].[dbo].[Feira] VALUES('Feira Empresarial','Feira C','Av.Eng.Pinheiro Braga 72, 4760-089','https://upload.wikimedia.org/wikipedia/commons/0/06/LinuxWorldBoston2006.agr.JPG','18/11/2022',1);

-- UPDATE [FamaFeiradb].[dbo].[Feira] SET imagem='https://upload.wikimedia.org/wikipedia/commons/0/06/LinuxWorldBoston2006.agr.JPG' WHERE idFeira=3;

INSERT INTO [FamaFeiradb].[dbo].[Stand] VALUES('Stand A','Inspirámo-nos em si e nos seus serviços para desenvolvermos o melhor da tecnologia para o seu negócio.','https://st.depositphotos.com/1637787/2927/i/450/depositphotos_29270411-stock-photo-happy-man-working-with-laptop.jpg','Rua dos Alfaiates 4756-453,Hotel Clementis','Consudigital',1,1,3);
INSERT INTO [FamaFeiradb].[dbo].[Stand] VALUES('Stand B','Colocámos os seus produtos à venda através de modelos e-commerce. Quer ser um fornecedor?','https://upcuesta.com.br/wp-content/uploads/2021/07/mulher-negra-trabalhand-em-home-office.jpg','Rua dos Caídos,4353-532- Motel Londrino,3 estrelas','ShipSell',1,1,3);

INSERT INTO [FamaFeiradb].[dbo].[Cliente] VALUES('João','joao','969123456','joaopass','joao@gmail.com','Rua dos Biscainhos-Braga');
INSERT INTO [FamaFeiradb].[dbo].[Cliente] VALUES('Alexandre','alex','936737262','alexpass','alex@gmail.com','Rua dos Fixes');
INSERT INTO [FamaFeiradb].[dbo].[Cliente] VALUES('Joana','joana','943847372','joanapass','joana@gmail.com','Rua dos aleijados');
INSERT INTO [FamaFeiradb].[dbo].[Cliente] VALUES('Luís','luis','935847311','luispass','luis@gmail.com','Rua dos inteligentes');
INSERT INTO [FamaFeiradb].[dbo].[Cliente] VALUES('Ana','ana','937362627','anapass','ana@gmail.com','Rua das Aninhas');


INSERT INTO [FamaFeiradb].[dbo].[Expositor] VALUES('Gaspar Noé','gasparnoe','gaspar123');
INSERT INTO [FamaFeiradb].[dbo].[Expositor] VALUES('Acácia','donacacia','acacia123');

INSERT INTO [FamaFeiradb].[dbo].[Produto] VALUES(999.99,'Projetor Samsung The Freestyle 2022','https://static.fnac-static.com/multimedia/Images/PT/NR/c8/4c/78/7883976/1541-1.jpg','C01X',1);
INSERT INTO [FamaFeiradb].[dbo].[Produto] VALUES(1559,'Laptop Microsoft Surface Studio Corei5-11300H','https://static.fnac-static.com/multimedia/Images/PT/NR/8e/e2/76/7791246/1541-1.jpg','C02X',1);
INSERT INTO [FamaFeiradb].[dbo].[Produto] VALUES(149.99,'Kobo Clara 2E','https://cdn.shopify.com/s/files/1/0933/2950/products/B_PT-Device_Angled_1080x1080_8a7c8264-439f-4504-b734-ccbc4adcb95b_652x652.jpg','C03X',1);


