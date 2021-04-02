<?php
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
header("Access-Control-Allow-Methods: POST");
header("Access-Control-Max-Age: 3600");
header("Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With");


include_once '../database.php';
include_once '../employees.php';
include_once '../token/token.php';

$security=getToken();
$token=$_POST['token'];
if($token==$security){

    $database = new Database();
    $db = $database->getConnection();
    $item = new Employee($db);

    $item->id = isset($_POST['id']) ? $_POST['id'] : die();

    if($item->deleteEmployee()){
        $data['status']='success';
        $data['message']='Employee data deleted successfully.';
        
    } else{
        $data['status']='failed';
        $data['message']='Employee data delete failed.';
        
    }
} else {
    $data['status']='denied';
    $data['message']='Unauthorize access.';
}
echo json_encode($data);
?>