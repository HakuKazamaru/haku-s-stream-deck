import { Component, OnInit, Input } from '@angular/core';
import { UntypedFormGroup, UntypedFormBuilder, UntypedFormControl, Validators, } from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

import { ModalService } from './modal.service';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html'
})
export class ModalComponent implements OnInit {
  @Input() buttonRow!: number;
  @Input() buttonCol!: number;
  @Input() buttonName!: string;
  @Input() buttonType!: number;
  @Input() buttonCommand!: string;
  @Input() buttonIcon!: string;
  @Input() buttonDescription!: string;


  public panelNum = 1;
  public buttonTypeList = [
    { name: 'SOUND', buttonTypeList: 1, displayName: '効果音再生' },
    { name: 'COMMAND', buttonTypeList: 2, displayName: 'プログラム実行' }
  ];

  buttonConfig: UntypedFormGroup;

  constructor(private formBuilder: UntypedFormBuilder, public activeModal: NgbActiveModal, private modal: ModalService) {
    
    this.buttonConfig = formBuilder.group(
      {
        /*
        panelNum: [1,{ updateOn: 'change' }],
        buttonRow: [0,{ updateOn: 'change' }],
        buttonCol: [0,{ updateOn: 'change' }],
        buttonName: ['',{ updateOn: 'change' }],
        selectButtonType: [0,{ updateOn: 'change' }],
        buttonCommand: ['',{ updateOn: 'change' }],
        buttonIcon: ['',{ updateOn: 'change' }],
        buttonDescription: ['',{ updateOn: 'change' }]
        */
      }
    );
  }

  get selectTest(): UntypedFormControl {
    return this.buttonConfig.get('selectButtonType') as UntypedFormControl;
  }

  ngOnInit(): void {

    console.log('[ngOnInit:Row ]' + this.buttonRow);
    console.log('[ngOnInit:Col ]' + this.buttonCol);
    console.log('[ngOnInit:Name]' + this.buttonName);
    console.log('[ngOnInit:Type]' + this.buttonType);
    console.log('[ngOnInit:Com ]' + this.buttonCommand);
    console.log('[ngOnInit:Icon]' + this.buttonIcon);
    console.log('[ngOnInit:Desc]' + this.buttonDescription);

    console.log('[ngOnInit]');
    this.selectTest.setValue(this.buttonTypeList[this.buttonType]);
  }

  public onClickOK() {
    console.log('[onClickOK]atart');

    console.log('[onClickOK:Row ]' + this.buttonRow);
    console.log('[onClickOK:Col ]' + this.buttonCol);
    console.log('[onClickOK:Name]' + this.buttonName);
    console.log('[onClickOK:Type]' + this.buttonType);
    console.log('[onClickOK:Com ]' + this.buttonCommand);
    console.log('[onClickOK:Icon]' + this.buttonIcon);
    console.log('[onClickOK:Desc]' + this.buttonDescription);

    /*
    this.modal.buttonData.row = this.buttonConfig.value.buttonRow;
    this.modal.buttonData.col = this.buttonConfig.value.buttonCol;
    this.modal.buttonData.buttonName = this.buttonConfig.value.buttonName;
    this.modal.buttonData.buttonType = this.buttonConfig.value.buttonType;
    this.modal.buttonData.buttonCommand = this.buttonConfig.value.buttonCommand.filename;
    this.modal.buttonData.buttonIcon = this.buttonConfig.value.buttonIcon.filename;
    this.modal.buttonData.buttonDescription = this.buttonConfig.value.buttonDescription;
    */
    console.log('[onClickOK]buttonName:' + this.modal.buttonData.buttonName);

    this.activeModal.close('ok');
  }

}
