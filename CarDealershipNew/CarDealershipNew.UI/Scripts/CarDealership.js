
function initMap() {
    // The location of Uluru
    var uluru = { lat: -25.344, lng: 131.036 };
    // The map, centered at Uluru
    var map = new google.maps.Map(
        document.getElementById('map'), { zoom: 4, center: uluru });
    // The marker, positioned at Uluru
    var marker = new google.maps.Marker({ position: uluru, map: map });
}









//////////////////////////////////
$(document).ready(function () {





});
///////////////////////////////////

document.getElementById('calculateLoan').addEventListener('click', calculateLoan)

function calculateLoan(e) {
    console.log("calculating");

    var amount = document.getElementById('loanAmount');
    var interest = document.getElementById('interest');
    var years = document.getElementById('term');
    var monthlyPayment = document.getElementById('monthlyPayment');
    var totalPayment = document.getElementById('totalPayment');
    var totalInterest = document.getElementById('totalInterest');

    var principal = parseFloat(amount.value);
    var calculatedInterest = parseFloat(interest.value) / 100 / 12;
    var calculatedPayments = parseFloat(years.value) * 12;

    var x = Math.pow(1 + calculatedInterest, calculatedPayments);
    var monthly = (principal * x * calculatedInterest) / (x - 1);

    if (isFinite(monthly)) {
        monthlyPayment.value = monthly.toFixed(2);
        totalPayment.value = (monthly * calculatedPayments).toFixed(2);
        totalInterest.value = ((monthly * calculatedPayments) - principal).toFixed(2);
    } else {
        console.log('check your information');
    }

}

////////////////////////////////////


function salesVehicleSearch() {
    $('#salesVehicleSearch').click(function (event) {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:54459/API/Sales',
            data: JSON.stringify({
                stringMakeModelOrYear: $('#salesMakeModelOrYearInput').val(),
                minPrice: $('#salesMinPrice').val(),
                maxPrice: $('#salesMaxPrice').val(),
                minYear: $('#salesMinYear').val(),
                maxYear: $('#salesMaxYear').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function (data) {
                $('#salesSearchResults').empty();
                $.each(data, function (key, vehicle) {
                    console.log(key, vehicle);
                    console.log(vehicle.Image);
                    var carId = vehicle.CarId;
                    var year = vehicle.Year;
                    var make = vehicle.Make;
                    var model = vehicle.Model;
                    var image = vehicle.Image;
                    var bodyStyle = vehicle.BodyStyle;
                    var transmission = vehicle.Transmission;
                    var exteriorColor = vehicle.ExteriorColor;
                    var interiorColor = vehicle.InteriorColor;
                    var mileage = vehicle.Mileage;
                    var vin = vehicle.VIN;
                    var price = vehicle.Price;
                    var msrp = vehicle.MSRP;

                    var row = `<div class="row vehicleRow">
                                <div class="col-sm-3">
                                    <p>${year} ${make} ${model}</p>
                                    <img class="card-img-bottom" src="/Images/car.jpg" alt="Card image cap"/>
                                </div>
                                <div class="col-sm-3">
                                    <p>Body Style: ${bodyStyle}</p>
                                    <p>Transmission: ${transmission}</p>
                                    <p>Color: ${exteriorColor}</p>
                                </div>
                                <div class="col-sm-3">
                                    <p>Interior: ${interiorColor}</p>
                                    <p>Mileage: ${mileage}</p>
                                    <p>VIN: ${vin}</p>
                                </div>
                                <div class="col-sm-3">
                                    <p>Sale Price: ${price}</p>
                                    <p>MSRP: ${msrp}</p>
                                    <a href="http://localhost:54459/Sales/Purchase/${carId}"><button type="button" class="btn btn - secondary">Purchase Vehicle</button></a>
                                </div>
                            </div>`;
                    $('#salesSearchResults').append(row);
                });
            },
            error: function () {
                $("#salesSearchResults")
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text("Error calling web service. Please try again later."));
            }
        });
    });

}


function vehicleSearch(Type) {
        $.ajax({
            type: 'POST',
            url: `http://localhost:54459/API/${Type}`,
            data: JSON.stringify({
                stringMakeModelOrYear: $('.makeModelOrYearInput').val(),
                minPrice: $('.minPrice').val(),
                maxPrice: $('.maxPrice').val(),
                minYear: $('.minYear').val(),
                maxYear: $('.maxYear').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function (data) {
                $('.detailsResult').empty();
                $.each(data, function (key, vehicle) {
                    console.log(key, vehicle);
                    console.log(vehicle.Image);
                    var carId = vehicle.CarId;
                    var year = vehicle.Year;
                    var make = vehicle.Make;
                    var model = vehicle.Model;
                    var image = vehicle.Image;
                    var bodyStyle = vehicle.BodyStyle;
                    var transmission = vehicle.Transmission;
                    var exteriorColor = vehicle.ExteriorColor;
                    var interiorColor = vehicle.InteriorColor;
                    var mileage = vehicle.Mileage;
                    var vin = vehicle.VIN;
                    var price = vehicle.Price;
                    var msrp = vehicle.MSRP;

                    var row = `<div class="row vehicleRow">
                                <div class="col-sm-3">
                                    <p>${year} ${make} ${model}</p>
                                    <img class="card-img-bottom" src="/Images/car.jpg" alt="Card image cap"/>
                                </div>
                                <div class="col-sm-3">
                                    <p>Body Style: ${bodyStyle}</p>
                                    <p>Transmission: ${transmission}</p>
                                    <p>Color: ${exteriorColor}</p>
                                </div>
                                <div class="col-sm-3">
                                    <p>Interior: ${interiorColor}</p>
                                    <p>Mileage: ${mileage}</p>
                                    <p>VIN: ${vin}</p>
                                </div>
                                <div class="col-sm-3">
                                    <p>Sale Price: ${price}</p>
                                    <p>MSRP: ${msrp}</p>
                                    <a href="http://localhost:54459/Home/GetDetails?id=${carId}"><button type="button" class="btn btn-secondary">Details</button></a>
                                </div>
                            </div>`;
                    $('.detailsResult').append(row);
                });
            },
            error: function () {
                $(".detailsResult")
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text("Error calling web service. Please try again later."));
            }
    });

}

function usedVehicleSearch() {
    $('#usedVehicleSearch').click(function (event) {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:54459/API/Used',
            data: JSON.stringify({
                stringMakeModelOrYear: $('#usedMakeModelOrYearInput').val(),
                minPrice: $('#usedMinPrice').val(),
                maxPrice: $('#usedMaxPrice').val(),
                minYear: $('#usedMinYear').val(),
                maxYear: $('#usedMaxYear').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function (data) {
                $('#usedSearchResults').empty();
                $.each(data, function (key, vehicle) {
                    console.log(key, vehicle);
                    console.log(vehicle.Image);
                    var carId = vehicle.CarId;
                    var year = vehicle.Year;
                    var make = vehicle.Make;
                    var model = vehicle.Model;
                    var image = vehicle.Image;
                    var bodyStyle = vehicle.BodyStyle;
                    var transmission = vehicle.Transmission;
                    var exteriorColor = vehicle.ExteriorColor;
                    var interiorColor = vehicle.InteriorColor;
                    var mileage = vehicle.Mileage;
                    var vin = vehicle.VIN;
                    var price = vehicle.Price;
                    var msrp = vehicle.MSRP;

                    var row = `<div class="row vehicleRow">
                                <div class="col-sm-3">
                                    <p>${year} ${make} ${model}</p>
                                    <img class="card-img-bottom" src="/Images/car.jpg" alt="Card image cap"/>
                                </div>
                                <div class="col-sm-3">
                                    <p>Body Style: ${bodyStyle}</p>
                                    <p>Transmission: ${transmission}</p>
                                    <p>Color: ${exteriorColor}</p>
                                </div>
                                <div class="col-sm-3">
                                    <p>Interior: ${interiorColor}</p>
                                    <p>Mileage: ${mileage}</p>
                                    <p>VIN: ${vin}</p>
                                </div>
                                <div class="col-sm-3">
                                    <p>Sale Price: ${price}</p>
                                    <p>MSRP: ${msrp}</p>
                                    <button type="button" class="btn btn-secondary" onclick="getDetails(${carId})">Details</button>
                                </div>
                            </div>`;
                    $('#usedSearchResults').append(row);
                });
            },
            error: function () {
                $("#errorMessages")
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text("Error calling web service. Please try again later."));
            }
        });
    });

}

//////////////////////

function adminVehicleSearch() {
    $('#adminVehicleSearch').click(function (event) {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:54459/API/Admin',
            data: JSON.stringify({
                stringMakeModelOrYear: $('#adminMakeModelOrYearInput').val(),
                minPrice: $('#adminMinPrice').val(),
                maxPrice: $('#adminMaxPrice').val(),
                minYear: $('#adminMinYear').val(),
                maxYear: $('#adminMaxYear').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function (data) {
                $('#adminSearchResults').empty();
                $.each(data, function (key, vehicle) {
                    console.log(key, vehicle);
                    console.log(vehicle.Image);
                    var carId = vehicle.CarId;
                    var year = vehicle.Year;
                    var make = vehicle.Make;
                    var model = vehicle.Model;
                    var image = vehicle.Image;
                    var bodyStyle = vehicle.BodyStyle;
                    var transmission = vehicle.Transmission;
                    var exteriorColor = vehicle.ExteriorColor;
                    var interiorColor = vehicle.InteriorColor;
                    var mileage = vehicle.Mileage;
                    var vin = vehicle.VIN;
                    var price = vehicle.Price;
                    var msrp = vehicle.MSRP;

                    var row = `<div class="row vehicleRow">
                                <div class="col-sm-3">
                                    <p>${year} ${make} ${model}</p>
                                    <img class="card-img-bottom" src="/Images/car.jpg" alt="Card image cap"/>
                                </div>
                                <div class="col-sm-3">
                                    <p>Body Style: ${bodyStyle}</p>
                                    <p>Transmission: ${transmission}</p>
                                    <p>Color: ${exteriorColor}</p>
                                </div>
                                <div class="col-sm-3">
                                    <p>Interior: ${interiorColor}</p>
                                    <p>Mileage: ${mileage}</p>
                                    <p>VIN: ${vin}</p>
                                </div>
                                <div class="col-sm-3">
                                    <p>Sale Price: ${price}</p>
                                    <p>MSRP: ${msrp}</p>
                                    <a href="http://localhost:54459/Admin/Edit?id=${carId}"><button type="button" class="btn btn-secondary">Edit</button></a>
                                </div>
                            </div>`;
                    $('#adminSearchResults').append(row);
                });
            },
            error: function () {
                $("#adminSearchResults")
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text("Error calling web service. Please try again later."));
            }
        });
    });
}

//////////////////////
//function getDetails(carId) {
//    $.ajax({
//        type: 'GET',
//        url: `http://localhost:54459/Home/GetDetails/${carId}`,
//        success: function (vehicle, status) {
//            $('.detailsResult').empty();
//            console.log(vehicle.Image);
//            var carId = vehicle.CarId;
//            var year = vehicle.Year;
//            var make = vehicle.Make;
//            var model = vehicle.Model;
//            var image = vehicle.Image;
//            var bodyStyle = vehicle.BodyStyle;
//            var transmission = vehicle.Transmission;
//            var exteriorColor = vehicle.ExteriorColor;
//            var interiorColor = vehicle.InteriorColor;
//            var mileage = vehicle.Mileage;
//            var vin = vehicle.VIN;
//            var price = vehicle.Price;
//            var msrp = vehicle.MSRP;
//            var description = vehicle.Description;

//            var row = `<div class="vehicleRow">
//                    <div class="row">
//                                <div class="col-sm-3">
//                                    <p>${year} ${make} ${model}</p>
//                                    <img class="card-img-bottom" src="/Images/car.jpg" alt="Card image cap"/>
//                                    <p></p>
//                                </div>
//                                <div class="col-sm-3">
//                                    <p>Body Style: ${bodyStyle}</p>
//                                    <p>Transmission: ${transmission}</p>
//                                    <p>Color: ${exteriorColor}</p>
//                                </div>
//                                <div class="col-sm-3">
//                                    <p>Interior: ${interiorColor}</p>
//                                    <p>Mileage: ${mileage}</p>
//                                    <p>VIN: ${vin}</p>
//                                </div>
//                                <div class="col-sm-3">
//                                    <p>Sale Price: ${price}</p>
//                                    <p>MSRP: ${msrp}</p>
//                                    <a class="nav-link" href="http://localhost:54459/Home/Contact/?vin=${vin}">
//                                    <button type="button" class="btn btn-secondary">Contact Us</button>
//                                    </a>   
//                                </div>
//                        </div>
//                        <div class="row">
//                            <div class="col-sm-12">
//                                <div class="row">
//                                    <div class="col-sm-3"> 
//                                    </div>
//                                    <div class="col-sm-9">
//                                        <p>Description: ${description}</p>
//                                    </div>
//                                </div>
//                            </div>    
//                        </div>
//                </div >`;
//            $('.detailsResult').append(row);

//        },
//        error: function () {
//            $(".detailsResult")
//                .append($('<li>')
//                    .attr({ class: 'list-group-item list-group-item-danger' })
//                    .text("Error calling web service. Please try again later."));
//        }
//    });
//}

////////////////////////

function purchaseVehicle(carId) {
    $.ajax({
        type: 'GET',
        url: `http://localhost:54459/Sales/Index/${carId}`,
        success: function (vehicle, status) {
            $('#salesSearchResults').empty();
            console.log("shit");
            console.log(vehicle.Image);
            var carId = vehicle.CarId;
            var year = vehicle.Year;
            var make = vehicle.Make;
            var model = vehicle.Model;
            var image = vehicle.Image;
            var bodyStyle = vehicle.BodyStyle;
            var transmission = vehicle.Transmission;
            var exteriorColor = vehicle.ExteriorColor;
            var interiorColor = vehicle.InteriorColor;
            var mileage = vehicle.Mileage;
            var vin = vehicle.VIN;
            var price = vehicle.Price;
            var msrp = vehicle.MSRP;
            var description = vehicle.Description;

            var row = `<div class="vehicleRow">
                    <div class="row">
                                <div class="col-sm-3">
                                    <p>${year} ${make} ${model}</p>
                                    <img class="card-img-bottom" src="/Images/car.jpg" alt="Card image cap"/>
                                    <p></p>
                                </div>
                                <div class="col-sm-3">
                                    <p>Body Style: ${bodyStyle}</p>
                                    <p>Transmission: ${transmission}</p>
                                    <p>Color: ${exteriorColor}</p>
                                </div>
                                <div class="col-sm-3">
                                    <p>Interior: ${interiorColor}</p>
                                    <p>Mileage: ${mileage}</p>
                                    <p>VIN: ${vin}</p>
                                </div>
                                <div class="col-sm-3">
                                    <p>Sale Price: ${price}</p>
                                    <p>MSRP: ${msrp}</p>
                                </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="row">
                                    <div class="col-sm-3"> 
                                    </div>
                                    <div class="col-sm-9">
                                        <p>Description: ${description}</p>
                                        <p>${carId}</p>
                                    </div>
                                </div>
                            </div>    
                        </div>
                </div >`;
            $('#salesSearchResults').append(row);
            $('#purchaseForm').empty();
            var form = `<form>
                            <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label for="inputEmail4">Name</label>
                                        <input type="text" class="form-control" id="inputEmail4" placeholder="Name">
                                    </div>
                                <div class="form-group col-md-8">
                                    <label for="inputPassword4">Phone</label>
                                    <input type="tel" class="form-control" id="inputPassword4" placeholder="555-555-5555">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputAddress">Email</label>
                                <input type="text" class="form-control" id="inputAddress" placeholder="Email">
                            </div>
                            <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label for="inputEmail4">Street1</label>
                                        <input type="text" class="form-control" id="inputEmail4" placeholder="Street1">
                                    </div>
                                <div class="form-group col-md-8">
                                    <label for="inputPassword4">Street2</label>
                                    <input type="text" class="form-control" id="inputPassword4" placeholder="Street2">
                                </div>
                            </div>
                            <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label for="inputEmail4">City</label>
                                        <input type="text" class="form-control" id="inputEmail4" placeholder="City">
                                    </div>
                                <div class="form-group col-md-8">
                                    <label for="inputPassword4">State</label>
                                    <div class="input-group mb-3">
                                    <select class="custom-select">
                                        <option selected>State</option>
                                    </select>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputAddress">Zipcode</label>
                                <input type="text" class="form-control" id="inputAddress" placeholder="55555">
                            </div>
                            <hr/>
                            <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label for="inputEmail4">Purchase Price</label>
                                        <input type="email" class="form-control" id="inputEmail4" placeholder="Price">
                                    </div>
                                <div class="form-group col-md-8">
                                    <label for="inputPassword4">Purchase Type</label>
                                    <div class="input-group mb-3">
                                    <select class="custom-select">
                                        <option selected>Dealer Finance</option>
                                    </select>
                                    </div>
                                </div>
                            </div>
                                <button type="submit" class="btn btn-primary" onclick="savePurchase()">Save</button>
                        </form>`;

            $('#purchaseForm').append(form);

        },
        error: function () {
            $("#salesSearchResults")
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text("Error calling web service. Please try again later."));
        }
    });
}