require 'net/http'

uri = URI('https://api.msrc.microsoft.com/engagebeta/ssi')

request = Net::HTTP::Post.new(uri.request_uri)
# Request headers
request['Content-Type'] = ''
# Request headers
request['Cache-Control'] = 'no-cache'
# Request headers
request['Ocp-Apim-Trace'] = ''
# Request headers
request['api-key'] = ' *******************'
# Request headers
request['Content-Type'] = 'application/json'
# Request headers
request['api-key'] = '{subscription key}'
# Request body
request.body = "{body}"

response = Net::HTTP.start(uri.host, uri.port, :use_ssl => uri.scheme == 'https') do |http|
    http.request(request)
end

puts response.body