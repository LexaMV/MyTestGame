using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : GameScriptAPI {
	int a = 0;
	/**
	 * Обработчик клика по ячейке
	 */
	protected override void HandleClick (int row, int col) {
		int value = GetValue (row, col);
		int sum = 0;

		#region Для самых крайних угловых блоков
		if (row == 0 && col == 0) {

			int a = GetValue (row + 1, col);
			int b = GetValue (row, col + 1);
			sum = a + b;

		} else if (row == rowCount - 1 && col == 0) {

			int a = GetValue (row, col + 1);
			int b = GetValue (row - 1, col);
			sum = a + b;

		} else if (row == 0 && col == colCount - 1) {

			int a = GetValue (row, col - 1);
			int b = GetValue (row + 1, col);
			sum = a + b;

		} else if (row == rowCount - 1 && col == colCount - 1) {

			int b = GetValue (row, col - 1);
			int c = GetValue (row - 1, col);
			sum = b + c;
		}
		#endregion

		#region Для блоков в крайних рядах, между угловыми блоками
		else if (row == 0 && col > 0 && col < colCount) {

			int a = GetValue (row, col - 1);
			int b = GetValue (row, col + 1);
			int c = GetValue (row + 1, col);
			sum = a + b + c;

		} else if (row == rowCount - 1 && col > 0 && col < colCount) {

			int a = GetValue (row, col - 1);
			int b = GetValue (row, col + 1);
			int c = GetValue (row - 1, col);
			sum = a + b + c;

		} else if (col == 0 && row > 0 && row < rowCount) {

			int a = GetValue (row - 1, col);
			int b = GetValue (row + 1, col);
			int c = GetValue (row, col + 1);
			sum = a + b + c;

		} else if (col == colCount - 1 && row > 0 && row < rowCount) {

			int a = GetValue (row - 1, col);
			int b = GetValue (row + 1, col);
			int c = GetValue (row, col - 1);
			sum = a + b + c;

		}

		#endregion

		#region Для всех остальных блоков
		else if (row + 1 < rowCount && row - 1 > -1) {
			if (col + 1 < colCount && col - 1 > -1) {

				int a = GetValue (row - 1, col);
				int b = GetValue (row + 1, col);
				int c = GetValue (row, col + 1);
				int d = GetValue (row, col - 1);
				sum = a + b + c + d;
				
			}
		}
		#endregion 

		SetValue (row, col, (value + sum));

		// SetValue(row, col, value == 0 ? 1 : 0);
	}

	/**
	 * Заполнить поле нулями
	 */
	public void FillZero () {
		for (int row = 0; row < rowCount; row++) {
			for (int col = 0; col < colCount; col++) {
				SetValue (row, col, 0);
				SetColor (row, col, colorTwo);
			}
		}
	}

	/**
	 * Пронумеровать ячейки
	 */
	public void FillNumber () {
		a = 0;
		for (int row = 0; row < rowCount; row++) {
			for (int col = 0; col < colCount; col++) {
				SetValue (row, col, a);
				SetColor (row, col, colorTwo);
				a++;
			}
		}
	}

	/**
	 * Произвольное заполнение
	 */
	public void FillCustom () { }

	void Start () {
		ResetErrors ();
		Rebuild ();
		// FillZero();
		FillNumber ();
	}

}