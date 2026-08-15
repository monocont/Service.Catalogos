CREATE TABLE IF NOT EXISTS catalogo.estado_comprobante (
    codigo          VARCHAR(2) NOT NULL,
    nombre          VARCHAR(60) NOT NULL,
    descripcion     VARCHAR(200),

    CONSTRAINT pk_estado_comprobante PRIMARY KEY (codigo)
);

INSERT INTO catalogo.estado_comprobante (codigo, nombre, descripcion) VALUES
('1', 'SIN OPERACIONES', 'Registrado en el libro electronico'),
('2', 'ANULADO', 'Comprobante anulado por el emisor'),
('3', 'USO INTERNO', 'Operacion de uso interno'),
('4', 'RESERVADO', 'Reservado para futuros usos SUNAT'),
('5', 'COMPROBANTE DE CONTINGENCIA', 'Emitido por contingencia'),
('6', 'INTERNAMIENTO', 'Operacion de internamiento'),
('7', 'TRANSITO', 'Operacion en transito'),
('8', 'EXPORTACION DEFINITIVA', 'Exportacion definitiva')
ON CONFLICT (codigo) DO NOTHING;
