require 'net/http'

uri = URI('https://api.msrc.microsoft.com/engage/cars')

request = Net::HTTP::Post.new(uri.request_uri)
request['Content-Type'] = 'application/json'
request['api-key'] = '{your api-key}'
request.body = "{
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
 }"

response = Net::HTTP.start(uri.host, uri.port, :use_ssl => uri.scheme == 'https') do |http|
    http.request(request)
end

puts response.body