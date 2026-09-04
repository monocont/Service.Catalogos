CREATE TABLE IF NOT EXISTS catalogo.tipo_doc_identidad (
    codigo          VARCHAR(10) NOT NULL,
    nombre          VARCHAR(60) NOT NULL,
    longitud_min    SMALLINT NOT NULL,
    longitud_max    SMALLINT NOT NULL,
    es_ruc          BOOLEAN NOT NULL DEFAULT FALSE,

    CONSTRAINT pk_tipo_doc_identidad PRIMARY KEY (codigo)
);

INSERT INTO catalogo.tipo_doc_identidad (codigo, nombre, longitud_min, longitud_max, es_ruc) VALUES
('0', 'NO DOMICILIADO',                       15, 15, FALSE),
('1', 'DNI',                                   8,  8, FALSE),
('4', 'CARNET DE EXTRANJERIA',               12, 12, FALSE),
('6', 'RUC',                                  11, 11, TRUE),
('7', 'PASAPORTE',                             7, 12, FALSE),
('A', 'CEDULA DIPLOMATICA DE IDENTIDAD',      12, 12, FALSE),
('B', 'DOC. IDENT. PAIS RESIDENCIA-NO DOM.', 15, 15, FALSE)
ON CONFLICT (codigo) DO NOTHING;
