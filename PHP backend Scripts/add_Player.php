<?php 

include_once('connects.php');
$player = $_GET['pname'];
$Score = $_GET['Score'];
$result = mysqli_query($con,"INSERT INTO playerdata (Player,Score) VALUE('$player','$Score')");
echo "Data Inserted";

?>