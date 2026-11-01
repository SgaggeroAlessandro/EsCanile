using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;

namespace EsCanile;

public partial class MainWindow : Window
{

    private readonly CCanile canile = new CCanile();

    public MainWindow()
    {
        InitializeComponent();
        canile.Carica();
        AggiornaLista();
        
    }

    private void AggiornaLista()
    {
        listaCani.ItemsSource = new List<CCane>(canile.Canile);
    }

    private void BtnAdotta_Click(object? sender, RoutedEventArgs e)
    {
        if (listaCani.SelectedItem is CCane caneSelezionato)
        {
            canile.AdottaCane(caneSelezionato);
            AggiornaLista();
            txtMessaggio.Text = "Cane adottato correttamente";
        }
        else
        {
            txtMessaggio.Text = "Seleziona un cane da adottare";
            return;
        }
    }


    private void BtnRegistra_Click(object? sender, RoutedEventArgs e)
    {
        string nome = txtNome.Text;

        if (string.IsNullOrWhiteSpace(nome))
        {
            txtMessaggio.Text = "Inserisci il nome del cane";
            return;
        }

        if(!int.TryParse(txtAnno.Text, out int annoNascita) || annoNascita <= 0 || annoNascita > DateTime.Now.Year){
            txtMessaggio.Text = "Inserisci l'anno di nascita del cane";
            return;
        }

        
        if(Razza.SelectedIndex < 0 || cmbStato.SelectedIndex < 0)
        {
            txtMessaggio.Text = "Seleziona razza e stato";
            return;
        }

        if (!DateTime.TryParse(txtDataIngresso.Text, out DateTime dataIngresso))
        {
            txtMessaggio.Text = "Inserisci una data valida.";
            return;
        }

        if (dataIngresso.Date > DateTime.Today)
        {
            txtMessaggio.Text = "La data di ingresso non può essere futura.";
            return;
        }

        RazzaCane razza = (RazzaCane)Razza.SelectedIndex;
        StatoCane stato = (StatoCane)cmbStato.SelectedIndex;

        try
        {
            CCane cane = new CCane(nome, annoNascita, razza, dataIngresso, stato, txtNote.Text);

            canile.AggiungiCane(cane);
            AggiornaLista();

            txtMessaggio.Text = "Cane aggiunto con successo";
        }catch(ArgumentException ex)
        {
            txtMessaggio.Text = ex.Message;
        }
        txtAnno.Text = "";
        txtDataIngresso.Text = "";
        txtMessaggio.Text = "";
        txtNome.Text = "";
        txtNote.Text = "";
        
    }
}