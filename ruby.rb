#This is a basic example of using Jitbit Helpdesk API with ruby (2.0+)
require 'net/http'
require 'json'

#creating the request URL
uri = URI.parse("https://XXX.jitbit.com/helpdesk/api/tickets")

http = Net::HTTP.new(uri.host, uri.port)
request = Net::HTTP::Get.new(uri.request_uri)

#adding the basic auth header
request.basic_auth("username", "password")

#getting the list of unanswered tickets for the authenticated user
response = http.request(request)

#parsing the JSON response and printing the subject of every ticket
tickets = JSON.parse(response.body)
tickets.each { |t| puts t["Subject"]}
