import random

#-----------------------------

estad= 713 + 1


Pais= "Uruguay"


IDpais= 188


#-----------------------------


archivo = open ("C:/Users/fanka/Documents/TEC/Espe y Dis/XFWC/Equipos/Temp.txt", "r")
archivoD = open ("C:/Users/fanka/Documents/TEC/Espe y Dis/XFWC/Equipos/" + Pais + ".txt", "w+")

booleanos = [True, False]

i = 1




for linea in archivo:
    linea = linea.rstrip()
    print (" %4d: %s "  % (i, linea))
    if i==1:
        archivoD.write( str( random.randint(12345678, 99999999) ) + "," ) #pasaporte
        archivoD.write( str(IDpais) + ","  ) #pais
    if i==3:
        archivoD.write(linea + ",") #posicion
    if i==4:
        archivoD.write(linea + ",") #nombre
    if i==5:
        archivoD.write(linea + ",") #fecha nacimiento
    if i==7:
        archivoD.write(linea + ",") #equipo
    if i==8:
        archivoD.write(linea + ",") #altura
    if i == 9:
        archivoD.write(linea + ",") #peso
        archivoD.write( str( random.randint(1, 10) )  + "," ) #precio
        archivoD.write( str( booleanos[random.randint(0,1)] ) + "," ) #activo
        archivoD.write( str( estad ) ) #idEstadistica

        archivoD.write("\n")
        estad+=1
        i=0
    i+=1

archivo.close()
archivoD.close()
