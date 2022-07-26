import 'dart:convert';
import 'dart:io';

import 'package:flutter/cupertino.dart';
import 'package:http/io_client.dart';

import '../model/product.dart';

class ProductProvider with ChangeNotifier {
  HttpClient client = new HttpClient();
  IOClient? http;

  ProductProvider() {
    print("called ProductProvider");
    client.badCertificateCallback = (cert, host, port) => true;
    http = IOClient(client);
  }

  Future<List<Product>> get(dynamic search) async {
    print("called ProductProvider.GET METHOD");
    var url = Uri.parse("https://10.0.2.2:7184/Proizvodi");

    String username = "test";
    String password = "test";

    String basicAuth =
        "Basic ${base64Encode(utf8.encode('$username:$password'))}";

    var headers = {
      "Content-Type": "application/json",
      "Authorization": basicAuth
    };

    var response = await http!.get(url, headers: headers);

    if (response.statusCode < 400) {
      var data = jsonDecode(response.body);
      List<Product> list =
          data.map((x) => Product.fromJson(x)).cast<Product>().toList();
      return list;
    } else {
      throw Exception("User not allowed!");
    }
  }
}
