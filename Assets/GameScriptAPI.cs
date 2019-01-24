using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScriptAPI: MonoBehaviour
{
	
	public int rowCount = 5;
	public int colCount = 5;
	
	public Color colorOne = Color.white;
	public Color colorTwo = Color.red;
	
	private GridLayoutGroup grid;
	
	private int error_count = 0;
	
	public GameObject errorPanel;
	public Text errorText;
	
	public void Rebuild()
	{
		int old_count = transform.childCount;
		if ( old_count < 1 )
		{
			return;
		}
		
		if ( rowCount < 1 ) rowCount = 1;
		if ( colCount < 1 ) colCount = 1;
		
		int new_count = rowCount * colCount;
		
		grid = GetComponent<GridLayoutGroup>();
		grid.constraintCount = rowCount;
		
		GameObject prefab = transform.GetChild(0).gameObject;
		
		for(int i = old_count-1; i > 0; i--)
		{
			GameObject.DestroyImmediate(transform.GetChild(i).gameObject);
		}
		
		for(int i = 1; i < new_count; i++)
		{
			GameObject obj = Instantiate(prefab, transform);
			obj.SetActive(true);
		}
	}
	
	/**
	 * Зафиксировать ошибку
	 */
	private void SetError()
	{
		error_count++;
		errorPanel.SetActive(true);
		errorText.text = "Ошибок: " + error_count;
	}
	
	/**
	 * Сбросить счетчик ошибок
	 */
	public void ResetErrors()
	{
		error_count = 0;
		errorPanel.SetActive(false);
	}
	
	protected bool CheckCoords(int row, int col)
	{
		if ( row < 0 || row >= rowCount )
		{
			return false;
		}
		
		if ( col < 0 || col >= colCount )
		{
			SetError();
			return false;
		}
		
		return true;
	}
	
	/**
	 * Получить ссылку на ячейку
	 */
	protected CellScript GetCell(int row, int col)
	{
		int num = row * colCount + col;
		return transform.GetChild(num).GetComponent<CellScript>();
	}
	
	/**
	 * Получить значение ячейки
	 */
	protected int GetValue(int row, int col)
	{
		if ( ! CheckCoords(row, col) )
		{
			SetError();
			return 0;
		}
		
		return GetCell(row, col).GetValue();
	}
	
	/**
	 * Установить значение ячейки
	 */
	protected void SetValue(int row, int col, int value)
	{
		if ( ! CheckCoords(row, col) )
		{
			SetError();
			return;
		}
		
		GetCell(row, col).SetValue(value);
	}
	
	/**
	 * Получить цвет ячейки
	 */
	protected Color GetColor(int row, int col)
	{
		if ( ! CheckCoords(row, col) )
		{
			SetError();
			return Color.white;
		}
		
		return GetCell(row, col).GetColor();
	}
	
	/**
	 * Установить цвет ячейки
	 */
	protected void SetColor(int row, int col, Color color)
	{
		if ( ! CheckCoords(row, col) )
		{
			SetError();
			return;
		}
		
		GetCell(row, col).SetColor(color);
	}
	
	/**
	 * Обработчик клика по ячейке
	 */
	protected virtual void HandleClick(int row, int col)
	{
	}
	
	/**
	 * Обработчик клика по ячейке
	 */
	public void OnClick(CellScript cell)
	{
		int id = cell.transform.GetSiblingIndex();
		int row = id / colCount;
		int col = id % colCount;
		try
		{
			HandleClick(row, col);
		}
		catch (Exception e)
		{
			SetError();
			Debug.LogException(e, this);
		}
	}
	
}
