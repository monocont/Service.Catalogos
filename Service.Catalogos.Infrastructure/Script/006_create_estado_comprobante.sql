CREATE TABLE IF NOT EXISTS catalogo.estado_comprobante (
    codigo          VARCHAR(10) NOT NULL,
    nombre          VARCHAR(60) NOT NULL,
    descripcion     VARCHAR(200) NOT NULL,
    afecta_igv      BOOLEAN NOT NULL DEFAULT TRUE,

    CONSTRAINT pk_estado_comprobante PRIMARY KEY (codigo)
);

INSERT INTO catalogo.estado_comprobante (codigo, nombre, descripcion, afecta_igv) VALUES
('0', 'OMITIDO', 'Comprobante de pago omitido (no propuesto por SUNAT, incluido por el contribuyente)', TRUE),
('1', 'VÁLIDO', 'Comprobante de pago válido / Emitido en el periodo de la declaración', TRUE),
('2', 'ANULADO', 'Comprobante de pago anulado / Dado de baja', FALSE),
('8', 'OMITIDO ANTERIOR', 'Comprobante de pago que corresponde a un periodo anterior y fue omitido', TRUE),
('9', 'RECTIFICADO ANTERIOR', 'Comprobante de pago que corresponde a un periodo anterior y se está rectificando o modificando', TRUE)
ON CONFLICT (codigo) DO UPDATE 
SET nombre = EXCLUDED.nombre,
    descripcion = EXCLUDED.descripcion,
    afecta_igv = EXCLUDED.afecta_igv;
