<?php
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
include_once '../database.php';
include_once '../employees.php';
include_once '../token/token.php';
include_once '../XML/Serializer.php';
$security=getToken();
$token=$_POST['token'];
if($token==$security){

    $database = new Database();
    $db = $database->getConnection();
    $items = new Employee($db);
    $records = $items->getEmployees();
    $itemCount = $records->num_rows;
    
    $data = array();
    if($itemCount > 0){
        
        $data["body"] = array();
        $data["itemCount"] = $itemCount;
        while ($row = $records->fetch_assoc())
        {
        array_push($data["body"], $row);
        }
        $data['status']='success';
        $data['message']='Records found.';
    }else{
        http_response_code(404);
        $data['status']='empty';
        $data['message']='No records found.';
        
    }
} else {
    $data['status']='denied';
    $data['message']='Unauthorize access.';
}
$serializer_options = array ( 

 
    'rootName' => 'empdata', 

    'defaultTagName' => 'employee', 

);
//$jsondata= json_encode($data);
//echo $jsondata;

$Serializer = new XML_Serializer($serializer_options); 


// Serialize the data structure 

$status = $Serializer->serialize($data); 


// Check whether serialization worked 

if (PEAR::isError($status)) { 

    die($status->getMessage()); 

} 


// Display the XML document 

header('Content-type: text/xml'); 

echo $Serializer->getSerializedData(); 

?>