CREATE TABLE IF NOT EXISTS catalogo.proyecto_inversion (
    codigo              VARCHAR(5) NOT NULL,
    descripcion         VARCHAR(200) NOT NULL,
    creado_por          VARCHAR(150),
    fecha_creacion      TIMESTAMP,
    modificado_por      VARCHAR(150),
    fecha_modificacion  TIMESTAMP,
    activo              BOOLEAN NOT NULL DEFAULT TRUE,

    CONSTRAINT pk_proyecto_inversion PRIMARY KEY (codigo)
);

INSERT INTO catalogo.proyecto_inversion (codigo, descripcion, activo, fecha_creacion) VALUES
('0','SIN PROYECTO', TRUE, NOW()),
('1','PROYECTOS DE INFRAESTRUCTURA PRODUCTIVA PUBLICA - IPP', TRUE, NOW()),
('2','PROYECTOS BANCOS DE INVERSION', TRUE, NOW()),
('3','OTROS PROYECTOS DE INVERSION', TRUE, NOW())
ON CONFLICT (codigo) DO NOTHING;
