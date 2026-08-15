CREATE TABLE IF NOT EXISTS catalogo.tipo_nota (
    codigo          VARCHAR(2) NOT NULL,
    descripcion     VARCHAR(200) NOT NULL,
    aplica_a        VARCHAR(2) NOT NULL,
    signo           CHAR(1) NOT NULL DEFAULT '-',

    CONSTRAINT pk_tipo_nota PRIMARY KEY (codigo),
    CONSTRAINT chk_tipo_nota_signo CHECK (signo IN ('+','-'))
);

INSERT INTO catalogo.tipo_nota (codigo, descripcion, aplica_a, signo) VALUES
('01','ANULACION DE LA OPERACION','00','-'),
('02','ANULACION POR ERROR EN EL RUC','00','-'),
('03','CORRECCION POR ERROR EN LA DESCRIPCION','00','+'),
('04','DESCUENTO GLOBAL','00','-'),
('05','DESCUENTO POR ITEM','00','-'),
('06','DEVOLUCION TOTAL','00','-'),
('07','DEVOLUCION POR ITEM','00','-'),
('08','BONIFICACION','00','-'),
('09','DISMINUCION EN EL VALOR','00','-'),
('10','OTROS CONCEPTOS','00','+'),
('11','AJUSTES DE OPERACION','00','+'),
('12','AJUSTES DE EXPORTACION','00','+')
ON CONFLICT (codigo) DO NOTHING;
