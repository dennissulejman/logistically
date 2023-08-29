# Logistically RESTful API

### Requirements

<p>A RESTful API that verifies if a package is valid or not. The maximum package measurements are as follows:</p>

* Weight: 20kg (Data model should be specified in grams)
* Length: 60cm
* Height: 60cm
* Width: 60cm

<p>If a package valid upon creation, the property called "IsValid" will be set to <strong>true</strong>, otherwise it will be set to <strong>false</strong>.</p>

<p>A package will be returned with a parcel ID that starts with "999" and is a total of 18 characters long.</p>

### Examples

#### Valid package

* ParcelId: 999000000000000000
* Weight: 10kg **(20kg max)**
* Length: 30cm **(60cm max)**
* Height: 30cm **(60cm max)**
* Width: 30cm **(60cm max)**

#### Invalid package

* ParcelId: 999000000000000001
* Weight: 30kg **(20kg max)**
* Length: 70cm **(60cm max)**
* Height: 75cm **(60cm max)**
* Width: 80cm **(60cm max)**