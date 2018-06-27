import pyodbc 
import json
# Some other example server values are
# server = 'localhost\sqlexpress' # for a named instance
# server = 'myserver,port' # to specify an alternate port

add_shelter = ("INSERT shelters ( shelter_name,shelter_address,shelter_phone_number, shelter_city, shelter_zip, shelter_email, shelter_latitude, shelter_longitude, shelter_ID) OUTPUT INSERTED.ID VALUES (?,?, ?, ?, ?, ?, ?, ?, ?)")  
add_pet= ("INSERT  pets ( pet_name, pet_breed1, pet_breed2, pet_gender, pet_description, pet_details,  pet_lastUpdated, pet_photosLink, shelter_ID, pet_ID, pet_type) OUTPUT INSERTED.ID VALUES (?,?, ?, ?, ?, ?, ?, ?, ?,?,?)")  


#sqlShelter = (name, address, phone,  city, zipCode, email,lat, long, shelterID)
#sqlPet = (pet_name, pet_breed1, pet_breed2,  pet_gender, pet_description,pet_details, pet_lastUpdated, pet_photosLink, shelterID, pet_ID, pet_type)


def getPetsJson():

    with open('pets_dict.json') as file:
         petsDict = json.load(file )
    
    return(petsDict)
    
def getSheltersJson():
    
     with open('shelter_dict.json') as file:
         sheltersDict = json.load(file )
     
     return(sheltersDict)

conn_str = (
    r'DRIVER={SQL Server};'
    r'SERVER=DESKTOP-7BEERKL\SQLEXPRESS;'
    r'DATABASE=pubs;'
    r'user=root;'
    
    r'autocommit=True'
)
cnxn = pyodbc.connect(conn_str)

cursor = cnxn.cursor()

#Create Shelters Table
#cursor.execute("CREATE TABLE shelters ("
#               "ID  int IDENTITY(1,1),"
#               "shelter_name VARCHAR(100),"
#               "shelter_address VARCHAR(100),"
#               "shelter_phone_number VARCHAR(60),"
#               "shelter_city VARCHAR(60),"
#               "shelter_zip  VARCHAR(60),"
#               "shelter_email VARCHAR(60),"
#               "shelter_latitude  FLOAT,"
#               "shelter_longitude  FLOAT,"
#               "shelter_ID VARCHAR(60),"
#               "PRIMARY KEY (ID))")

#sqlPet = (pet_name, pet_breed1, pet_breed2,  pet_gender, pet_description,detailHolder, pet_lastUpdated, pet_photosLink, shelterID, pet_ID, pet_type)

#Create Pets Table
#cursor.execute("CREATE TABLE pets ("
#               "ID  int IDENTITY(1,1),"
#               "pet_name Varchar(100),"
#               "pet_breed1 VARCHAR(100),"
#               "pet_breed2 VARCHAR(100),"
#               "pet_gender VARCHAR(100),"
#               "pet_description VARCHAR(MAX),"
#               "pet_details VARCHAR(100),"
#               "pet_lastUpdated VARCHAR(100),"
#               "pet_photosLink VARCHAR(MAX),"
#               "shelter_ID VARCHAR(100),"
#               "pet_ID VARCHAR(100),"
#               "pet_type VARCHAR(100),"
#               "PRIMARY KEY (ID))")

def insertShelters(sheltersDict):
 
#Start SQL Operation
#Connect to Database 
     
    conn_str = (
        r'DRIVER={SQL Server};'
        r'SERVER=DESKTOP-7BEERKL\SQLEXPRESS;'
        r'DATABASE=pubs;'
        r'user=root;'
        
        r'autocommit=True'
    )
    cnxn = pyodbc.connect(conn_str)
    
    cursor = cnxn.cursor()
    for shelter in sheltersDict:
      #  print(shelter)
       
       name =  shelter['name']['$t']
       if any(shelter['address1']):
           address =  shelter['address1']['$t']
       else:
           address = 'N/A'
       
       if any(shelter['phone']):
           phone =  shelter['phone']['$t']
       else:
           phone = 'N/A'
       city =  shelter['city']['$t']
       zipCode =  shelter['zip']['$t']
       email =   shelter['email']['$t']
       lat =  shelter['latitude']['$t']
       long = shelter['longitude']['$t']
       shelterID =   shelter['id']['$t']
        
        
       sqlShelter = (name, address, phone,  city, zipCode, email,lat, long, shelterID)
       cursor.execute(add_shelter,sqlShelter)
    
    cnxn.commit()
    cursor.close()
    cnxn.close()


def insertPets(petsDict):
#Start SQL Operation
#Connect to Database 
    conn_str = (
        r'DRIVER={SQL Server};'
        r'SERVER=DESKTOP-7BEERKL\SQLEXPRESS;'
        r'DATABASE=pubs;'
        r'user=root;'
        
        r'autocommit=True'
    )
    cnxn = pyodbc.connect(conn_str)
    
    cursor = cnxn.cursor()
    for pet in petsDict:
       print("flagggggggg")
       pet_name =  pet['name']['$t']
       print(pet_name)
       if any(pet['media']):
               pet_photosLink = str(pet['media']['photos'])
       else:
               pet_photosLink = 'N/A'
       pet_gender = pet['sex']['$t']
       if any(pet['description']):
               pet_description = pet['description']['$t']
#               print(pet_description)
#               print(" ")
       else:
               pet_description = 'N/A'
       print(pet_description)
       pet_lastUpdated = pet['lastUpdate']['$t']
       pet_type = pet['animal']['$t']
       pet_ID =  pet['id']['$t']
       shelter_ID = pet['shelterId']['$t']
       breeds = pet['breeds']['breed']
       if isinstance(breeds, list):
           pet_breed1 = breeds[0]['$t']
           pet_breed2 = breeds[1]['$t']
           
       else:
           pet_breed1 = breeds['$t']
           pet_breed2 = "N/A"
       
       if any(pet['options']):
           petDetails  = pet['options']['option']
    #       print (petDetails, pet_type)
           detailHolder = ""
           for detail in petDetails:
               if isinstance(detail, dict):
                   pet_detail = detail['$t']
                   detailHolder = detailHolder + " " + pet_detail
    
               else:
                   detailHolder = detail
    #               print(pet_detail, "flaggg")
               print(detailHolder)
       
       sqlPet = (pet_name, pet_breed1, pet_breed2,  pet_gender, pet_description,detailHolder, pet_lastUpdated, pet_photosLink, shelter_ID, pet_ID, pet_type)

       cursor.execute(add_pet,sqlPet)
       
    cnxn.commit()
    cursor.close()
    cnxn.close()  

petsDict = getPetsJson()
#sheltersDict = getSheltersJson()
#
#row = cursor.fetchone()
#insertShelters(sheltersDict)
insertPets(petsDict)
#print(petsDict[13])
cursor.commit()
cursor.close()
cnxn.close()
