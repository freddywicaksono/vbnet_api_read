<?php
function getToken(){
    $security=MD5('UMC.AC.ID' . date('Y-m-d'));
    return $security;
}
function array2xml( $array, $xml = false) {
    // Test if iteration
    if ( $xml === false ) {
      $xml = new SimpleXMLElement('<result/>');
    }
    
    // Loop through array
    foreach( $array as $key => $value ) {
        // Another array? Iterate
        if ( is_array( $value ) ) {
          array2xml( $value, $xml->addChild( $key ) );
        } else {
          $xml->addChild( $key, $value );
        }
    }
    
    // Return XML
    return $xml->asXML();
}
//UMC.AC.IDtahun-bulan-tanggal-> MD5 = token
//cth: UMC.AC.ID2021-04-01 -> diubah ke MD5 = token pada hari itu
?>

