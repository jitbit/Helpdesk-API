import json

import requests
from requests.auth import HTTPBasicAuth

# lets make a request
url = "https://XXX.jitbit.com/helpdesk/api/tickets"
authentication = HTTPBasicAuth('username', 'password')
response = requests.get(url, auth=authentication)
result = json.loads(response.content)
