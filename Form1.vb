Public Class Form1
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub NumericUpDown6_ValueChanged(sender As Object, e As EventArgs) Handles svr_rmosfeton.ValueChanged

    End Sub

    Private Sub NumericUpDown5_ValueChanged(sender As Object, e As EventArgs) Handles svr_rspoel.ValueChanged

    End Sub

    Private Sub NumericUpDown4_ValueChanged(sender As Object, e As EventArgs) Handles svr_iload.ValueChanged

    End Sub

    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles svr_diode.ValueChanged

    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles svr_vout.ValueChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SVR_BR_VIN As Single
        Dim SVR_BR_VOUT As Single
        Dim SVR_BR_VDIODE As Single
        Dim SVR_BR_ILOAD As Single
        Dim SVR_BR_RSPOEL As Single
        Dim SVR_BR_RMOSFET As Single

        Dim SVR_BR_DUTYCYCLE As Single
        Dim SVR_BR_PLOSSMOSFET As Single
        Dim SVR_BR_PLOSSDIODE As Single
        Dim SVR_BR_PLOSSSPOEL As Single
        Dim SVR_BR_PLOSSTOTAAL As Single
        Dim SVR_BR_nSR As Single

        SVR_BR_VIN = svr_vin.Value
        SVR_BR_VOUT = svr_vout.Value
        SVR_BR_VDIODE = svr_diode.Value
        SVR_BR_ILOAD = svr_iload.Value
        SVR_BR_RSPOEL = svr_rspoel.Value
        SVR_BR_RMOSFET = svr_rmosfeton.Value

        SVR_BR_DUTYCYCLE = SVR_BR_VOUT / SVR_BR_VIN
        svr_dutycycle.Text = SVR_BR_DUTYCYCLE

        SVR_BR_PLOSSMOSFET = Math.Pow(SVR_BR_ILOAD, 2) * SVR_BR_RMOSFET * SVR_BR_DUTYCYCLE
        svr_plossmosfet.Text = SVR_BR_PLOSSMOSFET

        SVR_BR_PLOSSDIODE = SVR_BR_ILOAD * SVR_BR_VDIODE * (1 - SVR_BR_DUTYCYCLE)
        svr_plossdiode.Text = SVR_BR_PLOSSDIODE

        SVR_BR_PLOSSSPOEL = Math.Pow(SVR_BR_ILOAD, 2) * SVR_BR_RSPOEL
        svr_plossspoel.Text = SVR_BR_PLOSSSPOEL

        SVR_BR_PLOSSTOTAAL = SVR_BR_PLOSSMOSFET + SVR_BR_PLOSSDIODE + SVR_BR_PLOSSSPOEL
        svr_plosstot.Text = SVR_BR_PLOSSTOTAAL

        SVR_BR_nSR = (SVR_BR_VOUT * SVR_BR_ILOAD) / ((SVR_BR_VOUT * SVR_BR_ILOAD) + SVR_BR_PLOSSTOTAAL) * 100
        svr_eff.Text = SVR_BR_nSR

        vr_svr_effbar.Value = SVR_BR_nSR

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim LVR_BR_VIN As Single
        Dim LVR_BR_VOUT As Single
        Dim LVR_BR_ILOAD As Single

        Dim LVR_BR_PLOSS As Single
        Dim LVR_BR_EFF As Single

        LVR_BR_VIN = lvr_vin.Value
        LVR_BR_VOUT = lvr_vout.Value
        LVR_BR_ILOAD = lvr_iload.Value

        LVR_BR_PLOSS = (LVR_BR_VIN - LVR_BR_VOUT) * LVR_BR_ILOAD
        lvr_ploss.Text = LVR_BR_PLOSS

        LVR_BR_EFF = ((LVR_BR_VOUT * LVR_BR_ILOAD) / ((LVR_BR_VOUT * LVR_BR_ILOAD) + LVR_BR_PLOSS)) * 100
        lvr_eff.Text = LVR_BR_EFF

        vr_lvr_effbar.Value = LVR_BR_EFF

        If LVR_BR_EFF < 20 Then
            MessageBox.Show("Het lijkt erop dat de lineaire spannings regulator niet erg efficiënt is. Is het misschien mogelijk om het verschil tussen te in- en output spanningen te verkleinen? Anders is het misschien een goed idee om de schakelende spannings regulator te gaan gebruiken.")
        End If
    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        MessageBox.Show("Persoonlijk zou ik je aanraden om het elektronica dictaat te kopen")
    End Sub

    Private Sub tr_tr_radNPN_CheckedChanged(sender As Object, e As EventArgs) Handles tr_tr_radNPN.CheckedChanged
        PictureBox13.Image = My.Resources.tr_tr_npn1
    End Sub

    Private Sub tr_tr_radPNP_CheckedChanged(sender As Object, e As EventArgs) Handles tr_tr_radPNP.CheckedChanged
        PictureBox13.Image = My.Resources.tr_tr_pnp1
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim TR_TR_IB As Single
        Dim TR_TR_BETA As Single

        Dim TR_TR_BR_IE As Single
        Dim TR_TR_BR_IC As Single

        TR_TR_IB = num_tr_iB.Value
        TR_TR_BETA = num_tr_beta.Value

        If tr_tr_radNPN.Checked Then
            TR_TR_BR_IC = TR_TR_IB * TR_TR_BETA
            tr_ic.Text = TR_TR_BR_IC

            TR_TR_BR_IE = TR_TR_BR_IC + TR_TR_IB
            tr_ie.Text = TR_TR_BR_IE
        Else
            TR_TR_BR_IC = TR_TR_IB * TR_TR_BETA
            tr_ic.Text = TR_TR_BR_IC


            tr_ie.Text = TR_TR_BR_IE
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim url As String = "https://github.com/4LM3R"
        Process.Start(url)
    End Sub
End Class
