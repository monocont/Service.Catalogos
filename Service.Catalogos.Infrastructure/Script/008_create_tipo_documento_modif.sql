CREATE TABLE IF NOT EXISTS catalogo.tipo_documento_modif (
    codigo          VARCHAR(10) NOT NULL,
    descripcion     VARCHAR(100) NOT NULL,

    CONSTRAINT pk_tipo_documento_modif PRIMARY KEY (codigo)
);

INSERT INTO catalogo.tipo_documento_modif (codigo, descripcion) VALUES
('01', 'FACTURA'),
('03', 'BOLETA'),
('07', 'NOTA DE CREDITO'),
('08', 'NOTA DE DEBITO'),
('14', 'RECIBO SERVICIOS PUBLICOS')
ON CONFLICT (codigo) DO NOTHING;
