import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-bio',
  templateUrl: './bio.component.html',
  styleUrls: ['./bio.component.css']
})
export class BioComponent implements OnInit {
  banners = [
    { imagePath: 'https://ugcorigin.s-microsoft.com/100/488459bc-c120-4e7b-a179-377f9bb41fc8/200/v1/image.jpg' },
    { imagePath: 'https://assets.online.berklee.edu/certificate-images/keyboard-styles-professional.jpg' },
    { imagePath: 'https://cdn.shopify.com/s/files/1/0279/3263/products/Cert_of_cert_pc_edit.jpg?v=1439491787' }
  ];

  banners2 = [
    { imagePath: 'https://ugcorigin.s-microsoft.com/100/488459bc-c120-4e7b-a179-377f9bb41fc8/200/v1/image.jpg' },
    { imagePath: 'https://assets.online.berklee.edu/certificate-images/keyboard-styles-professional.jpg' },
    { imagePath: 'https://cdn.shopify.com/s/files/1/0279/3263/products/Cert_of_cert_pc_edit.jpg?v=1439491787' }
  ];

  constructor() { }

  ngOnInit() {
  }


}
