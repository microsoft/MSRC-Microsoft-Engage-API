import http.client, urllib.request, urllib.parse, urllib.error, base64

headers = {
		'Content-Type': 'application/json',
		'api-key': '<your API key here>',
		}	
    
try:
	conn = http.client.HTTPSConnection('api.msrc.microsoft.com')
	reportBody = """{
	"testSubmission": true,
	"carsAdvancedCheck": true,
	"reporterInfo": {
		"reporterEmail": "yourname@yourorganization.com",
		"reporterName": "You",
		"reporterPhone": "555-555-5555",
		"reporterOrg": "YourOrganization",
		"discloseEmail": "TRUE",
		"reporterNotes": "This is a code sample test"
	},
	"reports": [
	{
		"report": {
			"reportNotes": "This is a test example from code on Git",
			"TLP": "WHITE",
			"disclosureNotes": "This is a test example from code on Git",
			"threats": [
			{
				"threat": {
					"threatType": "Activity",
					"threatSubType": "INTRUSION_ATTEMPT",
					"sampleType": "Base64",
					"sourceIp": "1.1.1.1",
					"destinationIp": "2.2.2.2",
					"sourcePort": "22",
					"destinationPort": "1433",
					"sourceUrl": "attacking url",
					"destinationUrl": "attacked url",
					"protocol": "foo",
					"byteCount": "600",
					"packetCount": "20",
					"date": "2017-01-01",
					"time": "00:00:00",
					"timeZone": "-00:00",
					"sample": "null"
					}
				}
			]
		}
	}
	]
	}"""
			 
	
	conn.request("POST", "/engage/cars", body=reportBody, headers=headers)
	response = conn.getresponse()
	data = response.read()
	print(data)
	conn.close()
			
except Exception as e:
	print("Something went wrong while reporting: " + str(e))
