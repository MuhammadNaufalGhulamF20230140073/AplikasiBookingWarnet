namespace booking
    partial class FormBooking
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.txtWaktu = new System.Windows.Forms.TextBox();
        this.txtDeviceID = new System.Windows.Forms.TextBox();
        this.txtUsername = new System.Windows.Forms.TextBox();
        this.txtbookingID = new System.Windows.Forms.TextBox();
        this.btnPesan = new System.Windows.Forms.Button();
        this.btnHapus = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.SuspendLayout();

        // txtWaktu
        this.txtWaktu.Location = new System.Drawing.Point(120, 100);
        this.txtWaktu.Name = "txtWaktu";
        this.txtWaktu.Size = new System.Drawing.Size(200, 22);
        this.txtWaktu.TabIndex = 0;
        // txtDeviceID
        this.txtDeviceID.Location = new System.Drawing.Point(120, 70);
        this.txtDeviceID.Name = "txtDeviceID";
        this.txtDeviceID.Size = new System.Drawing.Size(200, 22);
        this.txtDeviceID.TabIndex = 1;

        // txtUsername
        this.txtUsername.Location = new System.Drawing.Point(120, 40);
        this.txtUsername.Name = "txtUsername";
        this.txtUsername.ReadOnly = true;
        this.txtUsername.Size = new System.Drawing.Size(200, 22);
        this.txtUsername.TabIndex = 2;
        // txtbookingID
        this.txtbookingID.Location = new System.Drawing.Point(120, 10);
        this.txtbookingID.Name = "txtbookingID";
        this.txtbookingID.ReadOnly = true;
        this.txtbookingID.Size = new System.Drawing.Size(200, 22);
        this.txtbookingID.TabIndex = 3;
