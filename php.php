<?php
/* This is a basic example of using Jitbit Helpdesk API with PHP */
$url = "https://XXX.jitbit.com/helpdesk/api/tickets";
$username = "username";
$password = "password";


//initing curl
$curl = curl_init($url);
curl_setopt($curl, CURLOPT_USERPWD, $username  . ":" . $password);

//making the call
$curl_response = curl_exec($curl);

//error handling
if ($curl_response === false) {
    $info = curl_getinfo($curl);
    curl_close($curl);
    die('error occured during curl exec. Additioanl info: ' . var_export($info));
}
curl_close($curl);

//converting JSON response to an array of tickets
$tickets = json_decode($curl_response, true); 

//outputs the subject of the first ticket
echo $tickets[0]["Subject"];
?>
