<?php
$userName = 'admin';
$userApiKey = 'e93cd6f470eb5ffc0723cf0bcbd32714367b907f';
$nonce = base64_encode(substr(md5(uniqid()), 0, 16));
$created  = date('c');
$digest   = base64_encode(sha1(base64_decode($nonce) . $created . $userApiKey, true));

//$wsseHeader = "Authorization: WSSE profile=\"UsernameToken\"\n";
$wsseHeader = sprintf(
    'UsernameToken Username="%s", PasswordDigest="%s", Nonce="%s", Created="%s"',
    $userName,
    $digest,
    $nonce,
    $created
);

echo($wsseHeader);
?>