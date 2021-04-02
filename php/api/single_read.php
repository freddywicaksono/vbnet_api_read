<?php
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
header("Access-Control-Allow-Methods: POST");
header("Access-Control-Max-Age: 3600");
header("Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With");
include_once '../database.php';
include_once '../employees.php';
include_once '../token/token.php';
mysqli_report(MYSQLI_REPORT_ERROR | MYSQLI_REPORT_STRICT);
$security=getToken();
$token=$_POST['token'];
if($token==$security){

    $database = new Database();
    $db = $database->getConnection();
    $item = new Employee($db);
    $item->id = isset($_POST['id']) ? $_POST['id'] : die();
    $item->getSingleEmployee();
    if($item->name != null){

        // create array
        $data = array(
        "id" => $item->id,
        "name" => $item->name,
        "email" => $item->email,
        "designation" => $item->designation,
        "created" => $item->created,
        "status" => "success",
        "message" => "record found."
        );

        http_response_code(200);
        
    }else{
        
        $data['status']='empty';
        $data['message']='Data not found.';
        
    }
} else {
    $data['status']='denied';
    $data['message']='Unauthorize access.';
}
echo json_encode($data);
?>