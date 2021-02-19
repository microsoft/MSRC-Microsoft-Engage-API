import http.client, urllib.request, urllib.parse, urllib.error, base64

headers = {
  'Content-Type': 'application/json'
}

params = urllib.parse.urlencode({
})

try:
  conn = http.client.HTTPSConnection('https://api.msrc.microsoft.com')
  
  # Data model documentation at https://msrc.microsoft.com/report/developer
  str = "{}"
  
  conn.request("POST", "/report/v2.0/abuse?%s" % params, str, headers)
  response = conn.getresponse()
  data = response.read()
  conn.close()
except Exception as e:
  print("[Errno {0}] {1}".format(e.errno, e.strerror))
