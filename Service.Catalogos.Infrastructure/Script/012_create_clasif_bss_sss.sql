CREATE TABLE IF NOT EXISTS catalogo.clasif_bss_sss (
    codigo          VARCHAR(5) NOT NULL,
    nombre          VARCHAR(100) NOT NULL,
    descripcion     VARCHAR(500),

    CONSTRAINT pk_clasif_bss_sss PRIMARY KEY (codigo)
);

INSERT INTO catalogo.clasif_bss_sss (codigo, nombre, descripcion) VALUES
('1','BIENES','Bienes gravados'),
('2','SERVICIOS','Servicios gravados'),
('3','CONTRATOS DE CONSTRUCCION','Contratos de construccion'),
('4','BIENES Y SERVICIOS','Mixto'),
('5','OTROS','Otros conceptos'),
('10','BIENES EN GENERAL',NULL),
('20','SERVICIOS EN GENERAL',NULL),
('21','SERVICIOS PUBLICOS',NULL),
('30','CONTRATOS DE CONSTRUCCION',NULL)
ON CONFLICT (codigo) DO NOTHING;
