import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-test-sound-component',
  templateUrl: './test-sound.component.html'
})
export class PlaySoundComponent {
  public filePath = 'C:\\Windows\\Media\\tada.wav';
  public callResult = '未実行';
  postUrl = 'https://localhost:64859/Sound';

  constructor(private http: HttpClient) { }

  public playSound() {
    this.http.request(
      'GET',
      this.postUrl + '?' + 'filePath=' + this.filePath,
      { responseType: 'json' })
      .subscribe((data) => {
        this.callResult = data.toString();
        console.log(data);
      }, error => {
        this.callResult = "送信失敗";
        console.log(error);
      });
  }

  public playSoundByPost() {
    this.http
      .post<any>(this.postUrl, {
        filePath: this.filePath
      }).subscribe((data) => {
        this.callResult = data;
      },
        error => {
          this.callResult = "送信失敗";
          console.log(error);
        });
  }
}
