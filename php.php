<?php
$service_url = "http://XXX.jitbit.com/helpdesk/api/tickets";
$curl = curl_init($service_url);

curl_setopt($curl, CURLOPT_USERPWD, "admin:admin");
$curl_response = curl_exec($curl);
if ($curl_response === false) {
    $info = curl_getinfo($curl);
    curl_close($curl);
    die('error occured during curl exec. Additioanl info: ' . var_export($info));
}
curl_close($curl);
$decoded = json_decode($curl_response, true);

if (isset($decoded->response->status) && $decoded->response->status == 'ERROR') {
    die('error occured: ' . $decoded->response->errormessage);
}

echo $decoded[0]["Subject"];
?>