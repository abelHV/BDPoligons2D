-- ============================================================
-- ESTRUCTURA DE LA BASE DE DADES: bdPoligons2D
-- ============================================================


CREATE DATABASE IF NOT EXISTS bdPoligons2D
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_unicode_ci;
    

USE bdPoligons2D;

-- ------------------------------------------------------------
-- 1. TAULA TIPUS DE POLÍGON
-- ------------------------------------------------------------
CREATE TABLE tbTipusPoligon (
    NomTipusPoligon VARCHAR(30) PRIMARY KEY
);

INSERT INTO tbTipusPoligon (NomTipusPoligon) VALUES 
('Quadrat'), 
('Triangle Rectangle'), 
('Triangle Isòsceles'), 
('Triangle Equilàter'), 
('Rectangle'), 
('Cercle'), 
('Ellipse'), 
('Rombe'), 
('Pentàgon'), 
('Hexàgon'), 
('Heptàgon'), 
('Octògon');

-- ------------------------------------------------------------
-- 2. TAULA BASE: POLIGON
-- ------------------------------------------------------------
CREATE TABLE tbPoligon (
    IdPoligon INT AUTO_INCREMENT PRIMARY KEY,
    NomTipusPoligon VARCHAR(30) NOT NULL,
    CentreX INT NOT NULL,
    CentreY INT NOT NULL,
    NomColor VARCHAR(30) NULL, -- Si és NULL no té interior

    CONSTRAINT fk_poligon_tipus
        FOREIGN KEY (NomTipusPoligon) REFERENCES tbTipusPoligon(NomTipusPoligon)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
);

-- ------------------------------------------------------------
-- 3. SUBCLASSES DE TRIANGLES
-- ------------------------------------------------------------

CREATE TABLE tbTriangleRectangle (
    IdPoligon INT PRIMARY KEY,
    Base INT NOT NULL,
    Altura INT NOT NULL,
    CONSTRAINT fk_triRect_poligon FOREIGN KEY (IdPoligon) REFERENCES tbPoligon(IdPoligon) ON DELETE CASCADE
);

CREATE TABLE tbTriangleIsosceles (
    IdPoligon INT PRIMARY KEY,
    Base INT NOT NULL,
    Altura INT NOT NULL,
    CONSTRAINT fk_triIso_poligon FOREIGN KEY (IdPoligon) REFERENCES tbPoligon(IdPoligon) ON DELETE CASCADE
);

CREATE TABLE tbTriangleEquilater (
    IdPoligon INT PRIMARY KEY,
    Costat INT NOT NULL,
    CONSTRAINT fk_triEqui_poligon FOREIGN KEY (IdPoligon) REFERENCES tbPoligon(IdPoligon) ON DELETE CASCADE
);

-- ------------------------------------------------------------
-- 4. SUBCLASSES DE QUADRILÀTERS I FORMES RECTES
-- ------------------------------------------------------------

CREATE TABLE tbQuadrat (
    IdPoligon INT PRIMARY KEY,
    Mida INT NOT NULL,
    CONSTRAINT fk_quadrat_poligon FOREIGN KEY (IdPoligon) REFERENCES tbPoligon(IdPoligon) ON DELETE CASCADE
);

CREATE TABLE tbRectangle (
    IdPoligon INT PRIMARY KEY,
    Amplada INT NOT NULL,
    Altura INT NOT NULL,
    CONSTRAINT fk_rect_poligon FOREIGN KEY (IdPoligon) REFERENCES tbPoligon(IdPoligon) ON DELETE CASCADE
);

CREATE TABLE tbRombe (
    IdPoligon INT PRIMARY KEY,
    DiagMajor INT NOT NULL,
    DiagMenor INT NOT NULL,
    CONSTRAINT fk_rombe_poligon FOREIGN KEY (IdPoligon) REFERENCES tbPoligon(IdPoligon) ON DELETE CASCADE
);

-- ------------------------------------------------------------
-- 5. SUBCLASSES CURVES
-- ------------------------------------------------------------

CREATE TABLE tbCercle (
    IdPoligon INT PRIMARY KEY,
    Radi INT NOT NULL,
    CONSTRAINT fk_cercle_poligon FOREIGN KEY (IdPoligon) REFERENCES tbPoligon(IdPoligon) ON DELETE CASCADE
);

CREATE TABLE tbEllipse (
    IdPoligon INT PRIMARY KEY,
    RadiX INT NOT NULL,
    RadiY INT NOT NULL,
    CONSTRAINT fk_ellipse_poligon FOREIGN KEY (IdPoligon) REFERENCES tbPoligon(IdPoligon) ON DELETE CASCADE
);

-- ------------------------------------------------------------
-- 6. SUBCLASSES DE POLÍGONS REGULARS
-- ------------------------------------------------------------

CREATE TABLE tbPentagon (
    IdPoligon INT PRIMARY KEY,
    Radi INT NOT NULL,
    CONSTRAINT fk_penta_poligon FOREIGN KEY (IdPoligon) REFERENCES tbPoligon(IdPoligon) ON DELETE CASCADE
);

CREATE TABLE tbHexagon (
    IdPoligon INT PRIMARY KEY,
    Radi INT NOT NULL,
    CONSTRAINT fk_hexa_poligon FOREIGN KEY (IdPoligon) REFERENCES tbPoligon(IdPoligon) ON DELETE CASCADE
);

CREATE TABLE tbHeptagon (
    IdPoligon INT PRIMARY KEY,
    Radi INT NOT NULL,
    CONSTRAINT fk_hepta_poligon FOREIGN KEY (IdPoligon) REFERENCES tbPoligon(IdPoligon) ON DELETE CASCADE
);

CREATE TABLE tbOctogon (
    IdPoligon INT PRIMARY KEY,
    Radi INT NOT NULL,
    CONSTRAINT fk_octo_poligon FOREIGN KEY (IdPoligon) REFERENCES tbPoligon(IdPoligon) ON DELETE CASCADE
);


select * from tbPoligon
select * from tbQuadrat
select * from tbTriangleRectangle
select * from tbTriangleIsosceles
select * from tbTriangleEquilater
select * from tbRectangle
select * from tbCercle
select * from tbEllipse
select * from tbRombe
select * from tbPentagon
select * from tbHexagon
select * from tbHeptagon
select * from tbOctogon


