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
    idClinte INT IDENTITY(1,1) PRIMARY KEY ,
    nome VARCHAR(50) NOT NULL,
    username VARCHAR(50) NOT NULL,
    telemovel VARCHAR(50) NOT NULL,
    password VARCHAR(100) NOT NULL
);

-- DROP TABLE [FamaFeiradb].[dbo].[Feira] 
CREATE TABLE [FamaFeiradb].[dbo].[Feira](
    idFeira INT IDENTITY(1,1) PRIMARY KEY ,
    tipo VARCHAR(50) NOT NULL,
    localizacao VARCHAR(50) NOT NULL,
	imagem VARCHAR(150) NULL,
	dataFeira VARCHAR(50) NOT NULL,
	fk_idAdmin INT NULL,
    CONSTRAINT fk_Administrador FOREIGN KEY(fk_idAdmin) REFERENCES [FamaFeiradb].[dbo].[Administrador](idAdmin)
);

-- DROP TABLE [FamaFeiradb].[dbo].[Stand] 
CREATE TABLE [FamaFeiradb].[dbo].[Stand](
    idStand INT IDENTITY(1,1) PRIMARY KEY ,
    designacao VARCHAR(50) NOT NULL,
	descricao VARCHAR(150) NOT NULL,
	imagem VARCHAR(150) NOT NULL,
	recomendacao VARCHAR(50) NULL,
	empresa VARCHAR(50) NOT NULL,
    fk_idFeira INT NULL,
    CONSTRAINT fk_feira FOREIGN KEY(fk_idFeira) REFERENCES [FamaFeiradb].[dbo].[Feira](idFeira)
);


SELECT * FROM [FamaFeiradb].[dbo].[Cliente];
SELECT * FROM [FamaFeiradb].[dbo].[Feira];
SELECT * FROM [FamaFeiradb].[dbo].[Stand];
SELECT tipo,localizacao FROM [dbo].[Feira]
SELECT COUNT(username) as total FROM [FamaFeiradb].[dbo].[Cliente]
		WHERE username='joao';

SELECT S.designacao FROM [FamaFeiradb].[dbo].[Feira] AS F
	INNER JOIN [FamaFeiradb].[dbo].[Stand] AS S ON F.idFeira=S.fk_idFeira WHERE F.tipo='Feira de Cultura';

-- DELETE FROM [FamaFeiradb].[dbo].[Cliente]; 
-- DELETE FROM [FamaFeiradb].[dbo].[Feira]; 


INSERT INTO [FamaFeiradb].[dbo].[Administrador] VALUES('admin','admin123');

---apenas povoei a feira empresarial com 2 stands
INSERT INTO [FamaFeiradb].[dbo].[Feira] VALUES('Feira da Cultura','Av. de França 1361,4760-282','https://portalantigo.marica.rj.gov.br/wp-content/uploads/2017/01/DSC0091-FOTO-FERNANDO-SILVA.jpg','13/10/2022',1);
INSERT INTO [FamaFeiradb].[dbo].[Feira] VALUES('Feira de Artesanato','Rua de São Bento 217,4770-222 Joane','https://media-cdn.tripadvisor.com/media/photo-s/06/e5/27/8c/feira-de-arte-e-artesanato.jpg','16/10/2022',1);
INSERT INTO [FamaFeiradb].[dbo].[Feira] VALUES('Feira Empresarial','Av.Eng.Pinheiro Braga 72, 4760-089','https://upload.wikimedia.org/wikipedia/commons/0/06/LinuxWorldBoston2006.agr.JPG','18/11/2022',1);

-- UPDATE [FamaFeiradb].[dbo].[Feira] SET imagem='https://upload.wikimedia.org/wikipedia/commons/0/06/LinuxWorldBoston2006.agr.JPG' WHERE idFeira=3;

INSERT INTO [FamaFeiradb].[dbo].[Stand] VALUES('Stand A','Inspirámo-nos em si e nos seus serviços para desenvolvermos o melhor da tecnologia para o seu negócio.','https://st.depositphotos.com/1637787/2927/i/450/depositphotos_29270411-stock-photo-happy-man-working-with-laptop.jpg','Rua dos Alfaiates 4756-453,Hotel Clementis','Consudigital',3);
INSERT INTO [FamaFeiradb].[dbo].[Stand] VALUES('Stand B','Colocámos os seus produtos à venda através de modelos e-commerce. Quer ser um fornecedor?','https://upcuesta.com.br/wp-content/uploads/2021/07/mulher-negra-trabalhand-em-home-office.jpg','Rua dos Caídos,4353-532- Motel Londrino,3 estrelas','ShipSell',3);

INSERT INTO [FamaFeiradb].[dbo].[Cliente] VALUES('João','joao','969123456','joaopass');
INSERT INTO [FamaFeiradb].[dbo].[Cliente] VALUES('Alexandre','alex','936737262','alexpass');
INSERT INTO [FamaFeiradb].[dbo].[Cliente] VALUES('Joana','joana','943847372','joanapass');
INSERT INTO [FamaFeiradb].[dbo].[Cliente] VALUES('Luís','luis','935847311','luispass');
