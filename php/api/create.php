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


    $item->name = $_POST['name'];
    $item->email = $_POST['email'];
    $item->designation = $_POST['designation'];
    $item->created = date('Y-m-d H:i:s');
    
    if($item->createEmployee()){

        $data['status']='success';
        $data['message']='Employee data created successfully.';
    
    } else{

        $data['status']='failed';
        $data['message']='Employee data not created.';
    }
} else {

    $data['status']='denied';
    $data['message']='Unauthorize access.';

}
echo json_encode($data);
?>