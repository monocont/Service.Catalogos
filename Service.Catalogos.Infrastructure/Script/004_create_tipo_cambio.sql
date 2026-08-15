CREATE TABLE IF NOT EXISTS catalogo.tipo_cambio (
    codigo_moneda_origen    VARCHAR(3) NOT NULL,
    codigo_moneda_destino   VARCHAR(3) NOT NULL,
    fecha                   DATE NOT NULL,
    precio_compra           NUMERIC(5, 3) NOT NULL,
    precio_venta            NUMERIC(5, 3) NOT NULL,
    creado_por              VARCHAR(150),
    fecha_creacion          TIMESTAMP,
    modificado_por          VARCHAR(150),
    fecha_modificacion      TIMESTAMP,
    activo                  BOOLEAN NOT NULL DEFAULT TRUE,
    CONSTRAINT pk_tipo_cambio PRIMARY KEY (codigo_moneda_origen, codigo_moneda_destino, fecha),
    CONSTRAINT fk_tipo_cambio_moneda_origen FOREIGN KEY (codigo_moneda_origen) 
        REFERENCES catalogo.moneda(codigo_iso),
    CONSTRAINT fk_tipo_cambio_moneda_destino FOREIGN KEY (codigo_moneda_destino) 
        REFERENCES catalogo.moneda(codigo_iso)
);

CREATE INDEX IF NOT EXISTS idx_tipo_cambio_destino_fecha ON catalogo.tipo_cambio(codigo_moneda_destino, fecha);
CREATE INDEX IF NOT EXISTS idx_tipo_cambio_fecha ON catalogo.tipo_cambio(fecha);