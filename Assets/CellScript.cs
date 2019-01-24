using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellScript: MonoBehaviour
{
	
	/**
	 * Ссылка на текстовое поле
	 */
	public Text textField;
	
	/**
	 * Ссылка на кнопку
	 */
	public Button button;
	
	/**
	 * Значение ячейки
	 */
	private int m_value = 0;
	
	/**
	 * Цвет ячейки
	 */
	private Color m_color = Color.white;
	
	/**
	 * Ссылка на скрипт игры
	 */
	private GameScript game;
	
	public int GetValue()
	{
		return m_value;
	}
	
	public void SetValue(int value)
	{
		m_value = value;
		textField.text = value.ToString();
	}
	
	public Color GetColor()
	{
		return m_color;
	}
	
	public void SetColor(Color color)
	{
		m_color = color;
		ColorBlock cb = button.colors;
        cb.normalColor = color;
		button.colors = cb;
	}
	
	/**
	 * Привязать ячейку
	 */
	public void Bind(GameScript game)
	{
		this.game = game;
	}
	
	/**
	 * Обработчик клика по ячейке
	 */
	public void OnClick()
	{
		if ( game != null ) game.OnClick(this);
	}
}
