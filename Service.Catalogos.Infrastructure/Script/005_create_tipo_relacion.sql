CREATE TABLE IF NOT EXISTS catalogo.tipo_relacion (
    codigo          VARCHAR(5) NOT NULL,
    descripcion     VARCHAR(200) NOT NULL,

    CONSTRAINT pk_tipo_relacion PRIMARY KEY (codigo)
);

INSERT INTO catalogo.tipo_relacion (codigo, descripcion) VALUES
('E', 'EXPORTACION'),
('I', 'INTERNACION'),
('T', 'OTROS / TRANSITO')
ON CONFLICT (codigo) DO NOTHING;
