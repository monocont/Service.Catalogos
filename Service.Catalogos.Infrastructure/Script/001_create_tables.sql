CREATE SCHEMA IF NOT EXISTS catalogo;

CREATE TABLE IF NOT EXISTS catalogo.ubigeo (
    codigo_ubigeo           VARCHAR(6) NOT NULL,
    codigo_departamento     VARCHAR(10) NOT NULL,
    departamento            VARCHAR(100) NOT NULL,
    codigo_provincia        VARCHAR(4) DEFAULT NULL,
    provincia               VARCHAR(100) DEFAULT NULL,
    codigo_distrito         VARCHAR(6) DEFAULT NULL,
    distrito                VARCHAR(100) DEFAULT NULL,
    
    CONSTRAINT pk_ubigeo PRIMARY KEY (codigo_ubigeo)
);

CREATE INDEX IF NOT EXISTS idx_ubigeo_departamento ON catalogo.ubigeo(codigo_departamento);
CREATE INDEX IF NOT EXISTS idx_ubigeo_provincia ON catalogo.ubigeo(codigo_provincia);

CREATE TABLE IF NOT EXISTS catalogo.moneda (
    codigo_iso            VARCHAR(3) NOT NULL,
    nombre                VARCHAR(50) NOT NULL,
    simbolo               VARCHAR(5) NOT NULL,
    es_moneda_nacional    BOOLEAN NOT NULL DEFAULT FALSE,
    
    CONSTRAINT pk_moneda PRIMARY KEY (codigo_iso)
);
