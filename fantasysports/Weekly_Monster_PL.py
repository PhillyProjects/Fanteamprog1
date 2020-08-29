#
##
###
## Nicht ändern !!!! Wird bei Aufruf an das ausgewählte Turnier angepasst!!!!!
Game_ID = 255862
###
##
#
import time
import pandas as pd
from pandas import DataFrame
from sqlalchemy import create_engine
from datetime import date
import numpy as np
#
##
###
## Nicht ändern !!!! Datenbankzugriff
cnx = create_engine('mysql+pymysql://uxayl6sbtpqdhepa:QZPnMNX6OIJrkYTkes3F@bddiyuk2rbzdbj9pfb9r-mysql.services.clever-cloud.com:3306/bddiyuk2rbzdbj9pfb9r').connect()
sql = "select * from Projections where Turnier_ID = '"+str(Game_ID)+"'"
df = pd.read_sql(sql, cnx)
###
##
#
##################      Optimierung.       #####################################
## df enthält die relevanten Daten.

print(df)
time.sleep(20)
















#######################  df upload      ############################
### Ergebnis steht exeplarisch für das Gelöste Optimierungsproblem, Spieler 1-11, Proj, Preis, Turnier_ID und Datum in dieser Reihenfolge in erg speichern......   
Datum = date.today()
erg=[['1','2','3','4','5','6','7','8','9','10','11','80','100', str(Game_ID), str(Datum) ]]

Ergebnis =DataFrame(erg, columns=['Spieler1', 'Spieler2', 'Spieler3', 'Spieler4', 'Spieler5', 'Spieler6', 'Spieler7', 'Spieler8', 'Spieler9', 'Spieler10', 'Spieler11', 'Proj', 'Preis', 'TurnierID', 'Datum'])
Ergebnis.to_sql('Team_Opti',con=cnx, index=False, if_exists='append')
print(Ergebnis)
print( "Optimierung erfolgreich durchgeführt!!!")
time.sleep( 20 )

