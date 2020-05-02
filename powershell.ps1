function Get-Data([string]$username, [string]$password, [string]$url) {
  # Step 1. Create a username:password pair
  $credPair = "$($username):$($password)"
  # Step 2. Encode the pair to Base64 string
  $encodedCredentials = [System.Convert]::ToBase64String([System.Text.Encoding]::ASCII.GetBytes($credPair))
  # Step 3. Form the header and add the Authorization attribute to it
  $headers = @{ Authorization = "Basic $encodedCredentials" }
  # Step 4. Make the GET request
  $responseData = Invoke-WebRequest -Uri $url -Method Get -Headers $headers -UseBasicParsing
  return $responseData
}

// get tickets
$data = Get-Data -username user -password pass -url "https://XXX.jitbit.com/helpdesk/api/tickets"
$dataToDict = $data | ConvertFrom-Json

// Docs for Invoke-WebRequest are here: https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.utility/invoke-webrequest?view=powershell-6
// There you can learn how to send POST requests, add parameters, etc.
