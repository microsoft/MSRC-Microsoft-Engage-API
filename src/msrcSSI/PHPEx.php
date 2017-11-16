<?php
// This sample uses the Apache HTTP client from HTTP Components (http://hc.apache.org/httpcomponents-client-ga/)
require_once 'HTTP/Request2.php';

$request = new Http_Request2('https://api.msrc.microsoft.com/engagebeta/ssi');
$url = $request->getUrl();

$headers = array(
    // Request headers
    'Content-Type' => '',
    'Cache-Control' => 'no-cache',
    'Ocp-Apim-Trace' => '',
    'api-key' => ' *******************',
    'Content-Type' => 'application/json',
    'api-key' => '{subscription key}',
);

$request->setHeader($headers);

$parameters = array(
    // Request parameters
);

$url->setQueryVariables($parameters);

$request->setMethod(HTTP_Request2::METHOD_POST);

// Request body
$request->setBody("{body}");

try
{
    $response = $request->send();
    echo $response->getBody();
}
catch (HttpException $ex)
{
    echo $ex;
}

?>