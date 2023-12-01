CREATE TABLE SUPPLIER  ( S_SUPPID  INTEGER NOT NULL,
                            S_CONTACTINFO       CHAR(25) NOT NULL,
                            S_MAINADDRESS     VARCHAR(100) NOT NULL);

CREATE TABLE RESTRAUNT ( R_RESTRAUNTID     INTEGER NOT NULL,
                             R_NAME        VARCHAR(40) NOT NULL,
                             R_ADDRESS     VARCHAR(100) NOT NULL,
                             R_SUPPID   INTEGER NOT NULL,
                             R_CONTACTINFO       CHAR(15) NOT NULL,
                             R_PARENTCOMPANY     VARCHAR(40)   NOT NULL,
                             R_DININGTYPE  CHAR(40) NOT NULL);
							 
CREATE TABLE RATING  ( RA_RESTRAUNTID  INTEGER NOT NULL,
					  		RA_RATINGID INTEGER NOT NULL,
                            RA_MEDIANPRICERATING FLOAT NOT NULL,
                           	RA_MEANPRICERATING FLOAT NOT NULL,
					 		RA_GOOGLERATING FLOAT NOT NULL);
							
CREATE TABLE ITEMS  ( I_ITEMID  INTEGER NOT NULL,
					 		I_ITEMS VARCHAR(25)[] NOT NULL,
                            I_NAME VARCHAR(25) NOT NULL,
                           	I_ORIGIN VARCHAR(25) NOT NULL,
					 		I_PRICE FLOAT NOT NULL);
							
CREATE TABLE MENU  (M_RESTRAUNTID  INTEGER NOT NULL,
                            M_ITEMID INTEGER NOT NULL);