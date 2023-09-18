import {
  Component,
  ViewChild,
  AfterViewInit,
  OnInit,
  ElementRef
} from "@angular/core";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements AfterViewInit, OnInit {
  @ViewChild('tabnormal') tabnormal!: ElementRef;
  @ViewChild('tabxl') tabxl!: ElementRef;
  @ViewChild('tabmini') tabmini!: ElementRef;

  public normal = "block";
  public xl = "none";
  public mini = "none";

  ngAfterViewInit() {
    console.log('ngAfterViewInit', this.tabnormal);
    console.log('ngAfterViewInit', this.tabxl);
    console.log('ngAfterViewInit', this.tabmini);
  }

  ngOnInit() {
    console.log('ngOnInit', this.tabnormal);
    console.log('ngOnInit', this.tabxl);
    console.log('ngOnInit', this.tabmini);
  }

  public clickNormal() {
    this.normal = "block";
    this.xl = "none";
    this.mini = "none";

    if (!this.tabnormal.nativeElement?.classList.contains('active')) {
      this.tabnormal.nativeElement?.classList.add('active');
    }
    this.tabxl.nativeElement?.classList.remove('active');
    this.tabmini.nativeElement?.classList.remove('active');
  }

  public clickXl() {
    this.normal = "none";
    this.xl = "block";
    this.mini = "none";

    if (!this.tabxl.nativeElement?.classList.contains('active')) {
      this.tabxl.nativeElement?.classList.add('active');
    }
    this.tabnormal.nativeElement?.classList.remove('active');
    this.tabmini.nativeElement?.classList.remove('active');
  }

  public clickMini() {
    this.normal = "none";
    this.xl = "none";
    this.mini = "block";

    if (!this.tabmini.nativeElement?.classList.contains('active')) {
      this.tabmini.nativeElement?.classList.add('active');
    }
    this.tabxl.nativeElement?.classList.remove('active');
    this.tabnormal.nativeElement?.classList.remove('active');
  }
}
