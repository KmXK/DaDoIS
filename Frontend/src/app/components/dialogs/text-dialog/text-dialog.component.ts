import { DialogRef } from '@angular/cdk/dialog';
import { Component, inject } from '@angular/core';
import { MatButton } from '@angular/material/button';
import {
    MAT_DIALOG_DATA,
    MatDialogActions,
    MatDialogContent,
    MatDialogTitle
} from '@angular/material/dialog';
import { MatFormField } from '@angular/material/form-field';

@Component({
    selector: 'app-text-dialog',
    standalone: true,
    imports: [
        MatButton,
        MatDialogActions,
        MatDialogContent,
        MatDialogTitle,
        MatFormField
    ],
    templateUrl: './text-dialog.component.html',
    styleUrl: './text-dialog.component.scss'
})
export class TextDialog {
    private readonly dialogRef = inject(DialogRef<TextDialog>);
    public readonly data = inject<{
        title: string;
        text: string;
        button: string;
        action: () => void;
    }>(MAT_DIALOG_DATA);

    click() {
        this.data.action();
        this.dialogRef.close();
    }
}
