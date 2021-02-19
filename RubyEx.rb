require 'net/http'

uri = URI('https://api.msrc.microsoft.com/report/v2.0/abuse')

request = Net::HTTP::Post.new(uri.request_uri)
request['Content-Type'] = 'application/json'

# Data model documentation at https://msrc.microsoft.com/report/developer
request.body = "{}"

response = Net::HTTP.start(uri.host, uri.port, :use_ssl => uri.scheme == 'https') do |http|
    http.request(request)
end

puts response.body
